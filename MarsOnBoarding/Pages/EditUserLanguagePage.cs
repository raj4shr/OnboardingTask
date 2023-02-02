
namespace MarsOnBoarding;

public class EditUserLanguagePage
{
    private CommonSendKeysAndClick elementInteractions;
    private AddNewLanguagePage languagePage;
    private ScenarioContext? scenarioContext;
    private ReadOnlyCollection<IWebElement>? webElements;
    private string language,updatedLanguage;
    private bool UpdatedUserLanguage;
    private int rowIndex;

    private readonly By getAllBtnsInLanguageRow = By.TagName("span");
    private readonly By updateLanguageBtn = By.XPath("//input[@value='Update']");
    private readonly By getColumnsInLanguageRows = By.TagName("td");

    public EditUserLanguagePage(ScenarioContext _scenarioContext)
    {
        language = "";
        updatedLanguage = "";
        scenarioContext = _scenarioContext;
        UpdatedUserLanguage = false;
        rowIndex = -1;
        languagePage=new AddNewLanguagePage(scenarioContext);
        elementInteractions = new CommonSendKeysAndClick(scenarioContext);
    }

    public void GetAllColumnsInLanguageRows()
    {
        webElements=elementInteractions.ReturnAllElementsByLocator(getColumnsInLanguageRows);
    }
    public void ClickUpdateBtn()
    {
        elementInteractions.ClickOnElement(updateLanguageBtn);
    }

    public void CheckLanguageExists()
    {
        for (int i = 0; i < webElements.Count; i++)
        {
            if (webElements[i].Text.Equals(language) && i < webElements.Count)
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
        languagePage.ClickOnLanguageTab();
        GetAllColumnsInLanguageRows();
        //Check before edit if the language exists
        CheckLanguageExists();
        UpdatedUserLanguage = false;
        if (rowIndex >= 0)
        {

            webElements[rowIndex + 2].FindElements(getAllBtnsInLanguageRow)[0].Click();
            languagePage.InputNewLanguage(updatedLanguage);
            languagePage.SelectLanguageLevel(updatedLanguageLevel);
            ClickUpdateBtn();
            language=updatedLanguage;
        }
        elementInteractions.RefreshDriver();
        //Checking after the edit
        GetAllColumnsInLanguageRows();
        CheckLanguageExists();
    }
  
    public void UpdateAssertion()
    {
        UpdatedUserLanguage.Should().BeTrue();
    }
}
