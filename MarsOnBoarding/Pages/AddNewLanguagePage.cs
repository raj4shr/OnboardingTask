
namespace MarsOnBoarding;

public class AddNewLanguagePage
{
    private CommonSendKeysAndClick elementInteractions;
    private ReadOnlyCollection<IWebElement>? webElements;
    private ScenarioContext scenarioContext;
    private string? language;
    private bool addedUserLanguage;
    SelectElement languageLevelDropDownListBox;

    private readonly By languageBtn = By.XPath("//a[text()='Languages']");
    private readonly By addNewBtn = By.XPath("//div[text()='Add New']");
    private readonly By languageInputBox = By.XPath("//input[@placeholder='Add Language']");
    private readonly By languageLevelDropDown = By.Name("level");
    private readonly By addBtn = By.XPath("//input[@value='Add']");
    private readonly By allLanguageRowsColumns = By.TagName("td");

    public AddNewLanguagePage(ScenarioContext _scenarioContext)
    {
        scenarioContext = _scenarioContext;
        addedUserLanguage = false;
        elementInteractions = new CommonSendKeysAndClick(scenarioContext);
    }

    public void ClickOnLanguageTab()
    {
        elementInteractions.ClickOnElement(languageBtn);
    }

    public void ClickOnAddNewBtn()
    {
        elementInteractions.ReturnAllElementsByLocator(addNewBtn)[0].Click();
    }

    public void InputNewLanguage(string language)
    {
        elementInteractions.SendKeysTolement(languageInputBox, language);   
    }

    public void SelectLanguageLevel(string level)
    {
        languageLevelDropDownListBox=new SelectElement(elementInteractions.ReturnElement(languageLevelDropDown));
        languageLevelDropDownListBox.SelectByText(level);
    }

    public void ClickOnAddBtn()
    {
        elementInteractions.ClickOnElement(addBtn);
    }

    public void GetAllColumnsInLanguageRows()
    {
        webElements = elementInteractions.ReturnAllElementsByLocator(allLanguageRowsColumns);
    }

    public void AddNewUserLanguage(string userLanguage,string langFluency)
    {
        language = userLanguage;
        ClickOnLanguageTab();
        ClickOnAddNewBtn();
        InputNewLanguage(userLanguage);
        SelectLanguageLevel(langFluency);
        ClickOnAddBtn();
        elementInteractions.RefreshDriver();
        CheckLanguageAddedToUser();
    }

    public void CheckLanguageAddedToUser()
    {
        ClickOnLanguageTab();
        GetAllColumnsInLanguageRows();
        //checking all the columns for added language
        for (int i=0;i<webElements.Count;i++)
        {
            if(webElements[i].Text.Equals(language) && i< webElements.Count)
            {
                addedUserLanguage = true;
                break;
            }
        }
    }

    public void LanguageAddedAssertion()
    {
        addedUserLanguage.Should().BeTrue();
    }
}
