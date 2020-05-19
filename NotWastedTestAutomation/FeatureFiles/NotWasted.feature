Feature: NotWasted

Scenario: Verify the frequency based on bin selection for a particular address
	Given I navigate to the website
	And I click the button Order Bins Now on the header on the Main Page
	Then I get the search address modal
	When I add and select address : '3/17 Matata Street, Blockhouse Bay, Auckland, New Zealand' to the search modal
	Then I am on the Service Picker Page
	When I choose the service : "Food & Compostable Packaging"
	Then I get frequency : "Weekly Collections" with charge : "$17.75/collection"