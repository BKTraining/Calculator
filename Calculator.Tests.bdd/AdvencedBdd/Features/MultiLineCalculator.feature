Feature: MultiLineCalculator
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

	Background: 
		Given I'm browsing the calculator website 
		  And I'm on the Multiline calculator page
	

@MultilineCalculator
Scenario: Calculate a list of operation
	Given I have entered the following value in the textbox calculator
    | FirstValue | SecondValue | Operator       |
    | 10         | 10          | Subtraction    |
    | 50         | 10          | Subtraction    |
    | 10         | -10         | Multiplication |
    | 10         | 10          | Multiplication |
    | 1          | -5          | Division       |
    | 50         | 10          | Division       |
    | 0          | 10          | Division       |


	When I press result
	Then the result should be on the screen
	|  FirstValue	| SecondValue	| Operator			| Result	|
    | 10			| 10			| Subtraction       | 0         |
    | 50			| 10            | Subtraction       | 40		|
    | 10			| -10           | Multiplication    | -100		|
    | 10			| 10            | Multiplication    | 100		|
    | 1             | -5            | Division          | -0.2		|
    | 50			| 10            | Division          | 5         |
    | 0             | 10            | Division          | 0         |
