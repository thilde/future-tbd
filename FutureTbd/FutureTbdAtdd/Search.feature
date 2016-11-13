Feature: Search
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Simple Search Doesn't return Null
	Given Search For "Harvard"
	When Searching 
	Then Result is not "null"
