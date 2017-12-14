Feature: Poc
	In order inspect certificates on a machine
	As a user
	I want to be able to retrieve all certificates for the current user

@Critical
Scenario: Retrieve all certificates for the current user
	Given I selected the current user certificate suite from the machine I am on
	When I retrieve all certificates
	Then I make sure that certificates have been retrieved