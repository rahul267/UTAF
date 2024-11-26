Feature: BlazeDemo

Scenario: User successfully purchases a flight
Given the user is on the BlazeDemo website
When the user finds a flight
And the user chooses a flight
And the user purchases the flight
Then the user should see a confirmation message