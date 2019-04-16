Feature: Employee
	Responsible for verfiying Benefits, Create Employee,
	Delete employee and check if the functionality works.

Background: 
	Given I Delete employee 'AutoUser' before i start running test
@smoke
Scenario: Create Employee with all details
	Given I have navigated to the application
	And I see application opened
	Then I click login link
	When I enter UserName and Password and click login
	| UserName | Password |
	| admin    | password |
	Then I click login button
	And I click employeeList link
	Then I click createNew button
	Then I enter following details
	| Name     | Salary | DurationWorked | Grade | Email           |
	| AutoUser | 4000   | 30             | 1     | autouser@ea.com |
	And I click create button
