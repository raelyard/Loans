Feature: Acquire Loan
	In order to consume the written word
	As a passionate reader
	I want to find a book and borrow it

Scenario: Get a new Loan
	Given I have searched and found "Harry Potter and the Goblet of Fire"
	When I choose "Borrow"
	Then I should have a loan
