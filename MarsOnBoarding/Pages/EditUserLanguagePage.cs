
namespace MarsOnBoarding;

public class EditUserLanguagePage
{
    private CommonSendKeysAndClick findElements;
    private ScenarioContext? scenarioContext;
    private ReadOnlyCollection<IWebElement>? webElements;
    private string language,updatedLanguage;
    private bool UpdatedUserLanguage;
    private int rowIndex;
    private bool updateLang;

    public EditUserLanguagePage(ScenarioContext _scenarioContext)
    {
        language = "";
        updatedLanguage = "";
        scenarioContext = _scenarioContext;
        UpdatedUserLanguage = false;
        updateLang = false;
        rowIndex = -1;
        findElements = new CommonSendKeysAndClick(scenarioContext);
    }
    public void CheckLanguageExists()
    {
        string inputLanguage = "";
        webElements = findElements.findElementsByLocator(nameof(By.TagName), "td");
        Console.WriteLine(webElements.Count.ToString());
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
            if (webElements[i].Text.Equals(inputLanguage) && i < webElements.Count)
            {
                rowIndex = i;
                UpdatedUserLanguage=true;
                break;
            }
        }
    }

    
    public void EditUserLanguage(string userLanguage,string updatedLanguage,string updatedLanguageLevel)
    {
        language = userLanguage;
        this.updatedLanguage= updatedLanguage;
        //Checking before the edit
        CheckLanguageExists();
        if (rowIndex >= 0)
        {
            webElements = findElements.findElementsByLocator(nameof(By.TagName), "td");
            webElements[rowIndex + 2].FindElements(By.TagName("span"))[0].Click();
            findElements.sendKeysToElement(nameof(By.XPath), "//input[@placeholder='Add Language']", updatedLanguage);
            findElements.clickOnElement(nameof(By.XPath), "//select[@name='level']");
            findElements.clickOnElement(nameof(By.XPath), "//option[@value='" + updatedLanguageLevel + "']");
            findElements.clickOnElement(nameof(By.XPath), "//input[@value='Update']");
            Thread.Sleep(1000);
        }
        updateLang = true;
        rowIndex = 0;
        UpdatedUserLanguage = false;
        //Checking after the edit
        CheckLanguageExists();
    }

    public void UpdateAssertion()
    {
        UpdatedUserLanguage.Should().BeTrue();
    }
}
