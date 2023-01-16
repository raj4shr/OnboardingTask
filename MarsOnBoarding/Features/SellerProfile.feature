Feature: SellerProfile
Possible scenarios for the user profile page

Background: Login to the website
	Given User logs in to the website

## Following 5 scenarios are implemented for Onboarding Task 2
Scenario Outline: Add new Language
	When User adds a '<language>' and '<languageLevel>'
	Then the user language is added successfully on the user profile

	Examples: 
	| language | languageLevel    |
	| Telugu   | Native/Bilingual |
	| Hindi    | Fluent           |

Scenario Outline: Update Language
	When User updates a '<language>' to '<updatedLanguage>' and '<updatedLanguageLevel>'
	Then The language is updated successfully on the user profile

    Examples: 
    | language | updatedLanguage | updatedLanguageLevel |
    | French   | Spanish         | Basic                |

Scenario Outline: Delete Language
	When User deletes a '<language>'
	Then The language is deleted successfully from the user profile

    Examples: 
    | language |
    | English  |


Scenario Outline: Add new Skill
    When User adds a '<Skill>' and a '<SkillLevel>'

    Then the skill is added successfully on the user profile

    Examples: 
    | Skill    | SkillLevel   |
    | API      | Beginner     |
    | Selenium | Expert       |
    | C#       | Intermediate |


Scenario Outline: Add new Certification
    When User adds a '<Certification>', '<CertificationFrom>' and '<Year>'

    Then the certification is added successfully on the user profile

Examples: 
| Certification | CertificationFrom | Year |
| ISTQB CTFL    | ANZTB             | 2022 |
| AZ 900        | Microsoft         | 2023 |



##Following scenarios are written for Onboarding Task 1
@ignore
Scenario: Add new description
    When User adds the description

    Then The description is updated successfully on the user profile


@ignore
Scenario: Add new Education
    When User adds a education

    Then the education is updated successfully on the user profile

@ignore
Scenario: Change User Availability
    When User changes the availability

    Then User availability is updated successfully on the user profile

@ignore
Scenario: Change User Hours
    When User changes the hours

    Then User hours is updated successfully on the user profile

@ignore
Scenario: Change User Earn Target

    When User changes the earn target

    Then User earn target is updated successfully on the user profile

@ignore
Scenario: Cancel New Language Creation

    When User cancels a new language creation

    Then The new language is not added to the user profile

@ignore
Scenario: Cancel New Skill Creation

    When User cancels a new skill creation

    Then The new skill is not added to the user profile

@ignore
Scenario: Cancel New Education Creation

    When User cancels a new education creation

    Then The new education is not added to the user profile

@ignore
Scenario: Cancel New Certification Creation

    When User cancels a new certification creation

    Then The new certification is not added to the user profile

@ignore
Scenario: Delete Skill

    When User deletes a skill
    Then The skill is deleted successfully from the user profile

@ignore
Scenario: Delete Education

    When User deletes a education
    Then The education is deleted successfully from the user profile

@ignore
Scenario: Delete Certification

    When User deletes a Certification
    Then The certification is deleted successfully from the user profile

@ignore
Scenario: Update Skill

    When User updates a skill
    Then The skill is updated successfully on the user profile

@ignore
Scenario: Update Education

    When User updates a education
    Then The education is updated successfully on the user profile

@ignore
Scenario: Update Certification

    When User updates a certification
    Then The certification is updated successfully on the user profile

@ignore
Scenario: Cancel Update Language
    When User cancels a language update
    Then The language is not updated on the user profile

@ignore
Scenario: Cancel Update Skill
    When User cancels a skill update
    Then The skill is not updated on the user profile

@ignore
Scenario: Cancel Update Education
    When User cancels a education update
    Then The education is not updated on the user profile

@ignore
Scenario: Cancel Update Certification
    When User cancels a certification update
    Then The certification is not updated on the user profile

@ignore
Scenario: Update User First And Last Name

    When User updates his first/last name

    Then The user profile is updated successfuklky

@ignore
Scenario: Update Blank User First Name
    When User updates his first name with blank details

    Then The user is prompted with a message encouraging him to enter valid details

@ignore
Scenario: Update Blank User Last Name
    When User updates his last name with blank details

    Then The user is prompted with a message encouraging him to enter valid details

@ignore
Scenario: Update Blank User Description

    When User updates his description with blank details

    Then The user is prompted with a message encouraging him to enter valid details

@ignore
Scenario: Add Blank User language

    When User adds new language with blank details

    Then The user is prompted with a message encouraging him to enter valid details

@ignore
Scenario: Add Blank User Skill

    When User adds new skill with blank details

    Then The user is prompted with a message encouraging him to enter valid details

@ignore
Scenario: Add Blank User Education

    When User adds new education with blank details

    Then The user is prompted with a message encouraging him to enter valid details

@ignore
Scenario: Add Blank User Certificate

    When User adds new certificate with blank details

    Then The user is prompted with a message encouraging him to enter valid details

@ignore
Scenario: Update User Languge With Blank Values

    When User updates a language with black values

    Then The user is prompted with a message encouraging him to enter valid details

@ignore
Scenario: Update User Skill With Blank Values

    When User updates a skill with black values

    Then The user is prompted with a message encouraging him to enter valid details

@ignore
Scenario: Update User Education With Blank Values

    When User updates a education with black values

    Then The user is prompted with a message encouraging him to enter valid details

@ignore
Scenario: Update User Certificate With Blank Values

    When User updates a certificate with black values

    Then The user is prompted with a message encouraging him to enter valid details

@ignore
Scenario: Add Fifth User Language

    When User adds a fifth language

    Then The language is not added to the user profile and a message is displayed to the user saying only a maximum of 4 user languages are allowed



