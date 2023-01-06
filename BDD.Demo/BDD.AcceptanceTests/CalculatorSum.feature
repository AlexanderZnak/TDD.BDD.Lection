Feature: CalculatorSum
In order to use sum function
As user
I want to sum 2 plain numbers

    Scenario: Add two numbers
        And I have the first number 2
        And I have the second number 3
        When I Want to sum this numbers
        Then the result should be 5

    Scenario: Add two negative numbers
        Given I start calculator
        And I have the first number -2
        And I have the second number -3
        When I Want to sum this numbers
        Then the result should be -5

    Scenario: Add two long numbers
        Given I start calculator
        And I have the first number 11111111
        And I have the second number 2222222222222
        When I Want to sum this numbers
        Then the result should be 3333333333