
namespace MarsOnBoarding;

public class AddNewLanguagePage
{
    private CommonSendKeysAndClick findElements;
    private ReadOnlyCollection<IWebElement>? webElements;
    private ScenarioContext scenarioContext;
    private string? language;
    private string? languageLevel;
    private bool addedUserLanguage;

    public AddNewLanguagePage(ScenarioContext _scenarioContext)
    {
        scenarioContext = _scenarioContext;
        addedUserLanguage = false;
        findElements=new CommonSendKeysAndClick(scenarioContext);
    }

    public void AddNewUserLanguage(string userLanguage,string langFluency)
    {
        language = userLanguage;
        languageLevel= langFluency;
        findElements.clickOnElement(nameof(By.XPath), "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div");
        findElements.sendKeysToElement(nameof(By.XPath), "//input[@placeholder='Add Language']", userLanguage);
        findElements.clickOnElement(nameof(By.XPath), "//select[@name='level']");
        findElements.clickOnElement(nameof(By.XPath), "//option[@value='" + langFluency + "']");
        findElements.clickOnElement(nameof(By.XPath), "//input[@value='Add']");
        CheckLanguageAddedToUser();
    }

    public void CheckLanguageAddedToUser()
    {
        int rowIndex = 0;
        Thread.Sleep(2000);
        //checking all the columns for added language
        webElements = findElements.findElementsByLocatorElementExits(nameof(By.TagName), "td");
        for (int i=0;i<webElements.Count;i++)
        {
            if(webElements[i].Text.Equals(language) && i< webElements.Count)
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
