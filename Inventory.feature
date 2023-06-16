Feature: Inventory

As a registered user of the site ,
	User able to add  items to the cart ,
	user able to remove items from Cart

@Inventory
Scenario: Add items to the cart 
	Given standard user on Inventory page
	And I have "0" items in my cart
	When a product is added to cart
	Then I should have "1" item in the cart

@Inventory
Scenario: Cart continueshopping button navigates to inventorypage
	Given standard user on Inventory page
	And A product is added to cart
	When User clicks continueShopping 
	Then it redirects to Inventory Page

@Inventory
Scenario: Inventory Item displayed correctly in cart
	Given standard user on Inventory page
	When user add a products to cart
	| Key      | value           |
	| Product1 | labs-backpack   | 
	Then Correct Product details are displayed
	| Key             | value                                                                                                                                  |
	| Price           | $29.99                                                                                                                                 |
	| ItemName        | Sauce Labs Backpack                                                                                                                    |
	| ItemDescription | carry.allTheThings() with the sleek, streamlined Sly Pack that melds uncompromising style with unequaled laptop and tablet protection. |



