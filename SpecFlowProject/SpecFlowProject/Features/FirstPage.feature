@Mytest
Feature: Purchase Clothes
	
Scenario: Order the clothes
	Given user on the homepage	
	Then they can see the Black trousers product
	And they add it into the cart
	And they clicking the shop menu options
	And they add the Modern watches
	Then verify the 2 items in the cart

	Scenario: view products
		Given user on the homepage
		When they clicking the shop menu options
		Then they view the products of Top pants upper

		

