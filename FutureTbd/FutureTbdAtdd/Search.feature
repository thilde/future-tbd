Feature: Search
	In order to find more information about a specific university	
	As a highschool student
	I want to be able to search the university by it's name to find more information

@basic search
Scenario: Simple Search Doesn't return Null
	Given Search For "Harvard"
	When Searching 
	Then Result is not "null"

	Scenario: Search Using a Null Search Term returns Error Message
	Given Search For null
	When Searching
	Then Result contains error "The search term cannot be null"

	Scenario: Search Using an Empty String Search Term returns Error Message
	Given Search For ""
	When Searching
	Then Result contains error "The search term cannot be empty"

	
	Scenario: Search Using an White Space Search Term returns Error Message
	Given Search For "  "
	When Searching
	Then Result contains error "The search term cannot be empty"


	Scenario: Search Using a Short Search Term returns Error Message
	Given Search For "HA"
	When Searching
	Then Result contains error "The search term should be longer than 2 characters."

	Scenario: Search Using a Very Long Search Term returns Error Message
	Given Search For "HA111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111"
	When Searching
	Then Result contains error "The search term cannot be longer than 100 characters."

	
