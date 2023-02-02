
namespace MarsOnBoarding;

public class DeleteUserLanguagePage
{
    private ScenarioContext? scenarioContext;
    private readonly CommonSendKeysAndClick elementInteractions;
    private ReadOnlyCollection<IWebElement>? webElements;
    private bool deletedUserLanguage;
    private int rowIndex;

    private readonly By allColumnsInLanguageRows = By.TagName("td");
    private readonly By buttonsinLanguageRow = By.TagName("span");

    public DeleteUserLanguagePage(ScenarioContext _scenarioContext)
	{
		scenarioContext = _scenarioContext;
        deletedUserLanguage = false;
        rowIndex = -1;
        elementInteractions = new CommonSendKeysAndClick(scenarioContext);
	}

    public void GetAllColumnsFromLanguageRows()
    {
        webElements=elementInteractions.ReturnAllElementsByLocator(allColumnsInLanguageRows);
    }


    public void DeleteLanguage(string userLanguage)
    {
        CheckLanguageExists(userLanguage);
        DeleteUserLanguage();
    }

  public void CheckLanguageExists(string userLanguage)
    {
        GetAllColumnsFromLanguageRows();
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
            webElements[rowIndex + 2].FindElements(buttonsinLanguageRow)[1].Click();
            deletedUserLanguage = true;
        }

    }
  
    public void DeleteLanguageAssertion()
    {
        deletedUserLanguage.Should().BeTrue();
    }


}
