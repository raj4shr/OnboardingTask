
namespace MarsOnBoarding;

public class AddNewLanguagePage
{
    private readonly IWebDriver driver;
    private IWebElement? webElement;
    private ReadOnlyCollection<IWebElement>? webElements;
    private ScenarioContext scenarioContext;
    private readonly string language;
    private readonly string languageLevel;
    private bool addedUserLanguage;
    private int rowIndex;

    public AddNewLanguagePage(ScenarioContext _scenarioContext)
    {
        scenarioContext = _scenarioContext;
        driver = (IWebDriver)scenarioContext["driver"];
        language = "English";
        languageLevel = "Fluent";
        addedUserLanguage = false;
        rowIndex = 0;
    }

    public void AddNewUserLanguage(string userLanguage,string langFluency)
    {
        //Check if the user language which is being added is not already present, if it is, delete it first
        CheckLanguageAddedToUser();
        if (rowIndex > 0)
        {
            webElements = driver.FindElements(By.XPath("//td"));
            webElements[rowIndex + 2].FindElements(By.TagName("span"))[1].Click();
        }
        webElements = driver.FindElements(By.XPath("//div[text()='Add New']"));
        webElement = webElements[0];
        webElement.Click();
        webElement = driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
        webElement.SendKeys(userLanguage);
        webElement = driver.FindElement(By.XPath("//select[@name='level']"));
        webElement.Click();
        if(langFluency.Equals("Basic"))
        {
            webElement = driver.FindElement(By.XPath("//option[@value='Basic']"));
            webElement.Click();
        }
        else if(langFluency.Equals("Conversational"))
        {
            webElement = driver.FindElement(By.XPath("//option[@value='Conversational']"));
            webElement.Click();
        }
        else if (langFluency.Equals("Fluent"))
        {
            webElement = driver.FindElement(By.XPath("//option[@value='Fluent']"));
            webElement.Click();
        }
        else if (langFluency.Equals("Native"))
        {
            webElement = driver.FindElement(By.XPath("//option[@value='Native/Bilingual']"));
            webElement.Click();
        }
        webElement = driver.FindElement(By.XPath("//input[@value='Add']"));
        webElement.Click();
        Thread.Sleep(2000);
    }
    public void AddNewUserLanguage()
    {
        //Check if the user language which is being added is not already present, if it is, delete it first
        CheckLanguageAddedToUser();
        if(rowIndex>0)
        {
            webElements = driver.FindElements(By.XPath("//td"));
            webElements[rowIndex + 2].FindElements(By.TagName("span"))[1].Click();
        }
        webElements = driver.FindElements(By.XPath("//div[text()='Add New']"));
        webElement = webElements[0];
        webElement.Click();
        webElement = driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
        webElement.SendKeys(language);
        webElement = driver.FindElement(By.XPath("//select[@name='level']"));
        webElement.Click();
        webElement = driver.FindElement(By.XPath("//option[@value='Fluent']"));
        webElement.Click();
        webElement = driver.FindElement(By.XPath("//input[@value='Add']"));
        webElement.Click();
        Thread.Sleep(2000);
    }

    public void CheckLanguageAddedToUser()
    {
        //checking all the columns for added language
        webElements = driver.FindElements(By.TagName("td"));
        for (int i=0;i<webElements.Count;i++)
        {
            if(webElements[i].Text.Equals(language) && i< webElements.Count-1)
            {
                rowIndex = i;
                if(webElements[i+1].Text.Equals(languageLevel))
                {
                    addedUserLanguage = true;
                    break;
                }
            }
        }
    }

    public void LanguageAddedAssertion()
    {
        addedUserLanguage.Should().BeTrue();
    }
}
