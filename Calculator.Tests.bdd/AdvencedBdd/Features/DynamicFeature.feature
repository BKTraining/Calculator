Feature: DynamicFeature
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario Outline: Create set of dynamic objects
    When I create a set of dynamic instances from this table
        | Name   | Age | Birth date | Length in meters |
        | Marcus | 39  | 1972-10-09 | 1.96             |
        | Albert | 3   | 2008-01-24 | 1.03             |
        | Gustav | 1   | 2010-03-19 | 0.84             |
        | Arvid  | 1   | 2010-03-19 | 0.85             |
    Then the <itemNumber> item should have Age equal to <itemAge>

	Examples:
	    | itemNumber    | itemAge |
        | 1				| 39  |
        | 3				| 1   |
        | 4				| 1   |
        | 2				| 3   |

Scenario: Create set of dynamic objects v2
    When I create a set of dynamic instances from this table
        | Name   | Age | Birth date | Length in meters |
        | Marcus | 39  | 1972-10-09 | 1.96             |
        | Albert | 3   | 2008-01-24 | 1.03             |
        | Gustav | 1   | 2010-03-19 | 0.84             |
        | Arvid  | 1   | 2010-03-19 | 0.85             |
    Then the dynamic list of item will respecte those rules
	    | itemNumber    | itemAge |
        | 1				| 39  |
        | 3				| 1   |
        | 4				| 1   |
        | 2				| 3   |
