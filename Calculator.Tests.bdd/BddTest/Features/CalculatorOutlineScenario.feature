Feature: CalculatorOutlineScenario
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the result of an operation with two number

	Background: 
		Given I'm browsing the calculator website

@Calculator
Scenario Outline: Getting the result of an operation with two numbers
	Given I have entered <FirstValue> into the first operand of the calculator
	And I have choose  <Operation> as an operation into the calculator
	And I have entered <SecondValue> into the second operand of the calculator
	When I press result
	Then the result should be <Result> on the screen

	Examples:
	| FirstValue | SecondValue  | Operation			| Result |
	| 40         | 70           | Addition			| 110    |
	| 50         | 30           | Addition			| 80     |
	| -10		 | 10			| Addition			| 0		 |
	| -10		 | 10			| Subtraction		| -20	 |
	| -10		 | -10			| Subtraction		| 0		 |
	| 50		 | 10			| Subtraction		| 40	 |
	| -10		 | -10			| Multiplication	| 100	 |
	| -10		 | 10			| Multiplication	| -100	 |
	| 1			 | -5			| Division			| -0,2	 |
	| 50		 | 10			| Division			| 5		 |
	| 0			 | 10			| Division			| 0		 |


	@Calculator
Scenario: Division by 0 is not allowed
	Given I have entered 75 into the first operand of the calculator
	And I have choose Division as an operation into the calculator
	And I have entered 0 into the second operand of the calculator
	When I press result
	Then there is Division by zero is not allowed displayed on the screen
