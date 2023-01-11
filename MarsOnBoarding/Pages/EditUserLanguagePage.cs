
using FluentAssertions.Equivalency;
using Microsoft.VisualBasic;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Numerics;
using System.Threading.Channels;
using System.Xml.Linq;
using System;

namespace MarsOnBoarding;

public class EditUserLanguagePage
{
    private ScenarioContext? scenarioContext;
    private readonly IWebDriver driver;
    private ReadOnlyCollection<IWebElement>? webElements;
    private readonly string language,updatedLanguage;
    private bool UpdatedUserLanguage;
    private int rowIndex;
    private bool updateLang;
    private IWebElement? webElement;

    public EditUserLanguagePage(ScenarioContext _scenarioContext)
    {
        scenarioContext = _scenarioContext;
        UpdatedUserLanguage = false;
        language = "English";
        updatedLanguage = "Aramaic";
        updateLang = false;
        driver = (IWebDriver)scenarioContext["driver"];
        rowIndex = -1;
    }
    public void CheckLanguageExists()
    {
        //Checking if the language exists before the edit and checking again after the edit
        string inputLanguage = "";
        webElements = driver.FindElements(By.TagName("td"));
        if(updateLang==true)
        {
            inputLanguage = updatedLanguage;
        }
        else
        {
            inputLanguage = language;
        }
        for (int i = 0; i < webElements.Count; i++)
        {
            if (webElements[i].Text.Equals(inputLanguage) && i < webElements.Count - 1)
            {
                rowIndex = i;
                UpdatedUserLanguage=true;
                break;
            }
        }
    }

    
    public void EditUserLanguage()
    {
        //Checking before the edit
        CheckLanguageExists();
        if (rowIndex >= 0)
        {
            webElements = driver.FindElements(By.XPath("//td"));
            webElements[rowIndex + 2].FindElements(By.TagName("span"))[0].Click();

            webElement = driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
            webElement.Clear();
            webElement.SendKeys(updatedLanguage);
            webElement = driver.FindElement(By.XPath("//input[@value='Update']"));
            webElement.Click();
            Thread.Sleep(3000);
        }
        updateLang = true;
        rowIndex = 0;
        UpdatedUserLanguage= false;
        //Checking after the edit
        CheckLanguageExists();
    }

    public void UpdateAssertion()
    {
        UpdatedUserLanguage.Should().BeTrue();
    }
}

/*
##Following scenarios are written for Onboarding Task 1
@ignore
Scenario: Add new description
    When User adds the description

    Then The description is updated successfully on the user profile

@ignore
Scenario: Add new Skill
    When User adds a skill

    Then the skill is updated successfully on the user profile

@ignore
Scenario: Add new Education
    When User adds a education

    Then the education is updated successfully on the user profile

@ignore
Scenario: Add new Certifications
    When User adds a language

    Then the certification is updated successfully on the user profile

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

*/
