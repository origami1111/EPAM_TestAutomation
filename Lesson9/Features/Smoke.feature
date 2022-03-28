Feature: Smoke
	As a user
    I want to test all main functionality
    So that I can be sure that site works correctly

@mytag
Scenario Outline: Check that sign up is successful for user with next data
	Given user clicks sign up link
	And user enter <login> on username field for sign up
	And user enter <password> on password field for sign up
	When user clicks on sign up button
	Then user checks that sign up is successful

	Examples: 
	| login         | password |
	| !@#$%()(^&*() | a        |
	| Ac            | 123456   |

Scenario Outline: Check that users above can be logged in
	Given user clicks login link
	And user enter <login> on username field for login
	And user enter <password> on password field for login
	When user clicks on login button
	Then user checks that he is logged in

	Examples: 
	| login         | password |
	| !@#$%()(^&*() | a        |
	| Ac            | 123456   |

Scenario Outline: Check that user can purchase products from different products categories (Phones/Laptops/Monitors)
	Given user clicks <category> category
	And user select first product from list
	When user clicks on add to cart button
	Then user checks he can purchase product

	Examples: 
	| category |
	| Phones   |
	| Laptops  |
	| Monitors |