Feature: E-2-E
#
#A User Journey (e.g. Item – Inventory -Cart– Checkout) is successful  the website: https://www.saucedemo.com/
@E2E
Scenario: A standard user can  add 1 Item to basket and checkout sucessfully 
	Given standard user on Inventory page
	When a product is added to cart
	And filled in required form to checkout
	Then confirmation message displayed
@E2E
Scenario: A standard user can  add Multiple Items i.e.2 to basket and checkout sucessfully 
	Given standard user on Inventory page
	When user add two products to cart
	| Key      | value           |
	| Product1 | labs-backpack   |
	| Product2 | labs-bike-light |
	And filled in required form to checkout
	Then confirmation message displayed
@E2E
Scenario: A problem_user add 1 Item to basket and checkout sucessfully 
	Given  A "problem_user" on Inventory page
	When a product is added to cart
	And filled in required form to checkout
	Then confirmation message displayed

#Scenario: A Checkout view displays same price of a product as the results view
#	Given [context]
#	When [action]
#	Then [outcome]
#
#Scenario: A Checkout view displays correct tax amount based of value of product 
#	Given [context]
#	When [action]
#	Then [outcome]

