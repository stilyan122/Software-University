terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "3.114.0"
    }
  }
}

provider "azurerm" {
  skip_provider_registration = true
  features {}
}

resource "random_integer" "random" {
  min = 10000
  max = 99999
}

resource "azurerm_resource_group" "resource_group" {
  name = "ContanctBookRG${random_integer.random.result}"
  location = "West Europe"
}

resource "azurerm_service_plan" "service_plan" {
  name                = "contact-book-${random_integer.random.result}"
  location            = azurerm_resource_group.resource_group.location
  resource_group_name = azurerm_resource_group.resource_group.name
  sku_name            = "F1"
  os_type             = "Linux"
}

resource "azurerm_linux_web_app" "web_app" {
  name                = "contact-book-stilyan"
  resource_group_name = azurerm_resource_group.resource_group.name
  location            = azurerm_resource_group.resource_group.location
  service_plan_id     = azurerm_service_plan.service_plan.id

  site_config {
    application_stack {
      node_version = "16-lts"
    }
    always_on = false
  }
}

resource "azurerm_app_service_source_control" "source_control" {
  app_id               = azurerm_linux_web_app.web_app.id
  branch               = "master"
  repo_url             = "https://github.com/nakov/ContactBook"
  use_manual_integration = true
}