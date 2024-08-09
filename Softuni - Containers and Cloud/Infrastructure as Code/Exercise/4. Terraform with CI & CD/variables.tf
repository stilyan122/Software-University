variable "resource_group_name" {
  type        = string
  description = "Resource group name in Azure"
}

variable "resource_group_location" {
  type        = string
  description = "Resource group location in Azure"
}

variable "app_service_plan_name" {
  type        = string
  description = "App service plan name"
}

variable "app_service_name" {
  type        = string
  description = "App service name in Azure"
}

variable "sql_server_name" {
  type        = string
  description = "SQL server name in Azure"
}

variable "sql_database_name" {
  type        = string
  description = "SQL database name in Azure"
}

variable "sql_admin_login" {
  type        = string
  description = "SQL admin username"
}

variable "sql_admin_password" {
  type        = string
  description = "SQL admin password"
}

variable "firewall_rule_name" {
  type        = string
  description = "Firewall rule name"
}

variable "repo_URL" {
  type        = string
  description = "Repository URL in GH"
}

variable "storage_resource_group_name" {
  type        = string
  description = "Storage resource group name in Azure"
}

variable "storage_resource_group_location" {
  type        = string
  description = "Storage resource group location in Azure"
}

variable "storage_account_name" {
  type        = string
  description = "Storage account name in Azure"
}

variable "state_container_name" {
  type        = string
  description = "State container name in Azure"
}

variable "service_principal_app_name" {
  type        = string
  description = "State container name in Azure"
}

variable "sp_password" {
  description = "Password for the Azure AD service principal."
  type        = string
  sensitive   = true
}