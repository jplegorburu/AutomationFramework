Feature: Login
	Check if the login functionality is working
	as expected with different  permutations and 
	combination of data.

@smoke @positive
Scenario: Check login with correct username and password
	Given I have navigated to the application
	And I see application opened
	Then I click login link
	When I enter UserName and Password and click login
	| UserName | Password |
	| admin    | password |
	Then I click login button
	Then I should see the username with hello

