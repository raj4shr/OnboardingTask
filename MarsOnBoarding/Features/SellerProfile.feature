Feature: SellerProfile
Possible scenarios for the user profile page

Background: Login to the website
	Given User logs in to the website

##3 Following 3 scenarios are implemented for Onboarding Task 2
Scenario Outline: Add new Language
	When User adds a '<language>' and '<languageLevel>'
	Then the '<language>' and '<languageLevel>' is updated successfully on the user profile

	Examples: 
	| language | languageLevel |
	| English  | Fluent        |
	| French   | Basic         |
	| Telugu   | Native        |

Scenario: Update Language
	When User adds a language
	And User updates a language
	Then The language is updated successfully on the user profile

Scenario: Delete Language
	When User deletes a language
	Then The language is deleted successfully from the user profile

