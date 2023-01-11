
namespace MarsOnBoarding;

public class DeleteUserLanguagePage
{
    private ScenarioContext? scenarioContext;
    private readonly IWebDriver driver;
    private ReadOnlyCollection<IWebElement>? webElements;
    private readonly string language;
    private bool deletedUserLanguage;
    private int rowIndex;

    public DeleteUserLanguagePage(ScenarioContext _scenarioContext)
	{
		scenarioContext = _scenarioContext;
        language = "English";
        driver = (IWebDriver)scenarioContext["driver"];
        deletedUserLanguage = false;
        rowIndex = -1;
	}

    public void CheckLanguageExists()
    {
        //Checking if the language exists before deletion
        webElements = driver.FindElements(By.TagName("td"));
        for (int i = 0; i < webElements.Count; i++)
        {
            if (webElements[i].Text.Equals(language) && i < webElements.Count - 1)
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
            webElements = driver.FindElements(By.XPath("//td"));
            webElements[rowIndex + 2].FindElements(By.TagName("span"))[1].Click();
            deletedUserLanguage = true;
        }

    }

    public void DeleteLanguageAssertion()
    {
        deletedUserLanguage.Should().BeTrue();
    }


}
