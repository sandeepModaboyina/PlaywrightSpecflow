Feature: LoginFeature

Login Functionality with differnt supported users 
@Login
Scenario:Test: Check Login as standardUser navigates to Inventory page
	Given I am Saucedemo Homepage
	When I enter valid username and password
	| Key      | Value         |
	| User     | standard_user |
	| Password | secret_sauce  |
	Then it should navigate to Inventory page

@Login
Scenario Outline:Test: Check logins of differnt user
	Given I am Saucedemo Homepage
	When I enter given <UserName> and <Password>
	Then it should give me expected <Outcome>
	Examples: 
		| UserName        | Password     | Outcome                   |
		| standard_user   | secret_sauce | InventoryPage             |
		| locked_out_user | secret_sauce | Epic sadface              |
		| test            | Test         | CredentialValidationError |