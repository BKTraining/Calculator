Feature: MultiLineCalculator
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

	Background: 
		Given I'm browsing the calculator website 
		  And I'm on the Multiline calculator page
	

@MultilineCalculator @ignore
Scenario: Calculate a list of operation
	Given I have entered the following value in the textbox calculator
	|  FirstValue | Operator | SecondValue	|
	|    3		 | +		|    2			|
	|    1		 | -		|    1			|
	|    1		 | *		|    18			|
	When I press result
	Then the result should be on the screen
	|  FirstValue | Operator | SecondValue	| Result	|
	|	3		 | +		|    2			|   5		|
	|	1		 | -		|    1			|	0		|
	|	1		 | *		|    18			|	0		|
