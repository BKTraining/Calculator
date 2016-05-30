Feature: DynamicFeature
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

	Scenario: Create set of dynamic objects
    When I create a set of dynamic instances from this table
        | Name   | Age | Birth date | Length in meters |
        | Marcus | 39  | 1972-10-09 | 1.96             |
        | Albert | 3   | 2008-01-24 | 1.03             |
        | Gustav | 1   | 2010-03-19 | 0.84             |
        | Arvid  | 1   | 2010-03-19 | 0.85             |
    Then the 3 item should have Age equal to '1'