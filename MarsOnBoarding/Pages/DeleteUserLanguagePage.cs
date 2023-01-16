
namespace MarsOnBoarding;

public class DeleteUserLanguagePage
{
    private ScenarioContext? scenarioContext;
    private readonly CommonSendKeysAndClick findElements;
    private ReadOnlyCollection<IWebElement>? webElements;
    private bool deletedUserLanguage;
    private int rowIndex;

    public DeleteUserLanguagePage(ScenarioContext _scenarioContext)
	{
		scenarioContext = _scenarioContext;
        deletedUserLanguage = false;
        rowIndex = -1;
        findElements=new CommonSendKeysAndClick(scenarioContext);
	}

    public void CheckLanguageExists(string userLanguage)
    {
        webElements = findElements.findElementsByLocator(nameof(By.TagName), "td");
        for (int i = 0; i < webElements.Count; i++)
        {
            if (webElements[i].Text.Equals(userLanguage) && i < webElements.Count - 1)
            {
                rowIndex = i;
                break;
            }
        }
    }

    public void DeleteUserLanguage()
    {
        //Deleting the row as per the index in the table
        if (rowIndex >= 0)
        {
            webElements = findElements.findElementsByLocator(nameof(By.XPath), "//td");
            webElements[rowIndex + 2].FindElements(By.TagName("span"))[1].Click();
            deletedUserLanguage = true;
        }

    }

    public void DeleteLanguageAssertion()
    {
        deletedUserLanguage.Should().BeTrue();
    }


}
