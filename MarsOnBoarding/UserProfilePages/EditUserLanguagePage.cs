
using OpenQA.Selenium;

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
        updatedLanguage = "French";
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
