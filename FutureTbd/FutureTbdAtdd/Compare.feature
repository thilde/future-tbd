Feature: Compare
    In order to be able to compare between multiple universities	
	As a highschool student
	I want to be able to add them to a comparison list to learn more about them

@mytag
Scenario: Compare Page Request
	Given Request To Compare
	When Comparing Results
	Then Compare Result Is Not Null
