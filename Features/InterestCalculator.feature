Feature: Interest Calculator Test Cases

Scenario: The application should provide options to choose the duration for interest calculation: Daily, Monthly, and Yearly
	Given I am logged in to calculator
	Then daily monthly and yearly options should be displayed

Scenario: Users should be able to input the principal amount
	Given I am logged in to calculator
	When I drag principle amount slider
	Then principle amount should be filled

Scenario: Users should be able to select the interest rate from a predefined list of rates up to 15%
	Given I am logged in to calculator
	When I select interest rate
	Then selected interest rate should be 15%

Scenario: The application should calculate the correct interest based on the selected duration, principal amount, and interest rate
	Given I am logged in to calculator
	When I select duration
	And I select principle amount
	And I select interest rate
	And I select consent checkbox
	And I click calculate button
	Then correct interest rate should be calculated

Scenario: The application should display the calculated interest and the total amount including interest
	Given I am logged in to calculator
	When I select duration
	And I select principle amount
	And I select interest rate
	And I select consent checkbox
	And I click calculate button
	Then correct total amount should be displayed

Scenario: All input fields (principal amount, interest rate, duration and consent) are mandatory
	Given I am logged in to calculator
	When I click calculate button
	Then mandatory fields should be validated

Scenario: Calculated interest and total amount should be rounded to two decimal places
	Given I am logged in to calculator
	When interest rate is calculated
	Then calculated interest rate should be rounded to two decimals
	And total amount should be rounded to two decimals






