Feature: Login
In order to be logged in
As an user
I want to have permissions to use website

    Scenario: Successful login
        Given I go to website demoblaze.com
        When I click button Login
        And I fill in form
        And I submit form
        Then User should be logged in
        And Quite browser

    Scenario: Successful login an attempt 2
        Given I go to website demoblaze.com at the HomePage
        When I want to log in
        Then User should be logged in