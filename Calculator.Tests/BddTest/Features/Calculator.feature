Feature: Calculator
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@Calculator
Scenario: Add two numbers
	Given I have entered 50 into the first operand of the calculator
	And I have choose Addition as an operation into the calculator
	And I have entered 70 into the second operand of the calculator
	When I press result
	Then the result should be 120 on the screen

@Calculator
Scenario: Substract two numbers
	Given I have entered 75 into the first operand of the calculator
	And I have choose Subtraction as an operation into the calculator
	And I have entered 24 into the second operand of the calculator
	When I press result
	Then the result should be 51 on the screen

@Calculator
Scenario: Multiply two numbers
	Given I have entered 8 into the first operand of the calculator
	And I have choose Multiplication as an operation into the calculator
	And I have entered 9 into the second operand of the calculator
	When I press result
	Then the result should be 72 on the screen

@Calculator
Scenario: Division of two numbers
	Given I have entered 75 into the first operand of the calculator
	And I have choose Division as an operation into the calculator
	And I have entered 25 into the second operand of the calculator
	When I press result
	Then the result should be 3 on the screen


@Calculator
Scenario: Division by 0 is not allowed
	Given I have entered 75 into the first operand of the calculator
	And I have choose Division as an operation into the calculator
	And I have entered 0 into the second operand of the calculator
	When I press result
	Then there is Division by zero is not allowed displayed on the screen