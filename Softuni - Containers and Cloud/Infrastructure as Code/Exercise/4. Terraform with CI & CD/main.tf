terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "~> 3.0" # Replace with the appropriate version constraint
    }
    azuread = {
      source  = "hashicorp/azuread"
      version = "~> 2.0" # Replace with the appropriate version constraint
    }
  }
}

provider "azurerm" {
  features {}
}

provider "azuread" {
  # No version constraints here
}

# Resource Group for Terraform State
resource "azurerm_resource_group" "storage_rg" {
  name     = var.storage_resource_group_name
  location = var.storage_resource_group_location
}

# Storage Account
resource "azurerm_storage_account" "storage_account" {
  name                     = var.storage_account_name
  resource_group_name      = azurerm_resource_group.storage_rg.name
  location                 = azurerm_resource_group.storage_rg.location
  account_tier             = "Standard"
  account_replication_type = "LRS"
}

# Storage Container for State
resource "azurerm_storage_container" "state_container" {
  name                  = var.state_container_name
  storage_account_name  = azurerm_storage_account.storage_account.name
  container_access_type = "private"
}

# Azure AD Application
resource "azuread_application" "app" {
  display_name = var.service_principal_app_name
}

# Azure AD Service Principal
resource "azuread_service_principal" "sp" {
  application_id = azuread_application.app.application_id
}

# Azure AD Service Principal Password
resource "azuread_service_principal_password" "sp_password" {
  service_principal_id = azuread_service_principal.sp.id
  end_date             = "2099-01-01T00:00:00Z"
}

# Role Assignment
resource "azurerm_role_assignment" "sp_role" {
  principal_id   = azuread_service_principal.sp.id
  role_definition_name = "Contributor"
  scope          = azurerm_resource_group.storage_rg.id
}

# Resource Group for Application Deployment
resource "azurerm_resource_group" "resource_group" {
  name     = var.resource_group_name
  location = var.resource_group_location
}

# SQL Server
resource "azurerm_mssql_server" "server" {
  name                         = var.sql_server_name
  resource_group_name          = azurerm_resource_group.resource_group.name
  location                     = azurerm_resource_group.resource_group.location
  version                      = "12.0"
  administrator_login          = var.sql_admin_login
  administrator_login_password = var.sql_admin_password
}

# SQL Database
resource "azurerm_mssql_database" "database" {
  name           = var.sql_database_name
  server_id      = azurerm_mssql_server.server.id
  collation      = "SQL_Latin1_General_CP1_CI_AS"
  license_type   = "LicenseIncluded"
  max_size_gb    = 2
  sku_name       = "S0"
  zone_redundant = false
}

# SQL Firewall Rule
resource "azurerm_mssql_firewall_rule" "firewall_rule" {
  name             = var.firewall_rule_name
  server_id        = azurerm_mssql_server.server.id
  start_ip_address = "0.0.0.0"
  end_ip_address   = "0.0.0.0"
}

# App Service Plan
resource "azurerm_service_plan" "service_plan" {
  name                = var.app_service_plan_name
  resource_group_name = azurerm_resource_group.resource_group.name
  location            = azurerm_resource_group.resource_group.location
  os_type             = "Linux"
  sku_name            = "F1"
}

# Web App
resource "azurerm_linux_web_app" "web_app" {
  name                = var.app_service_name
  resource_group_name = azurerm_resource_group.resource_group.name
  location            = azurerm_resource_group.resource_group.location
  service_plan_id     = azurerm_service_plan.service_plan.id

  site_config {
    application_stack {
      dotnet_version = "6.0"
    }
    always_on = false
  }

  connection_string {
    name  = "DefaultConnection"
    type  = "SQLAzure"
    value = "Data Source=tcp:${azurerm_mssql_server.server.fully_qualified_domain_name},1433;Initial Catalog=${azurerm_mssql_database.database.name};User ID=${azurerm_mssql_server.server.administrator_login};Password=${azurerm_mssql_server.server.administrator_login_password};Trusted_Connection=False; MultipleActiveResultSets=True;"
  }
}

# App Service Source Control
resource "azurerm_app_service_source_control" "source_control" {
  app_id                 = azurerm_linux_web_app.web_app.id
  branch                 = "master"
  repo_url               = var.repo_URL
  use_manual_integration = true
}