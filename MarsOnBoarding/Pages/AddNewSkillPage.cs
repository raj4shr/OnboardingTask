
namespace MarsOnBoarding;

public class AddNewSkillPage
{
    private ReadOnlyCollection<IWebElement>? webElements;
    private ScenarioContext scenarioContext;
    private string skill;
    private bool addedUserSkill;
    private readonly CommonSendKeysAndClick elementInteractions;
    private readonly IWebDriver driver;
    private SelectElement skillLevelDropDownListBox;

    private readonly By skillsBtn = By.XPath("//a[text()='Skills']");
    private readonly By addNewBtn = By.XPath("//div[text()='Add New']");
    private readonly By skillInputBox = By.XPath("//input[@placeholder='Add Skill']");
    private readonly By skillLevelDropdown = By.Name("level");
    private readonly By addBtn = By.XPath("//input[@value='Add']");
    private readonly By allColumnsInSkillRows = By.TagName("td");

    public AddNewSkillPage(ScenarioContext _scenarioContext)
    {
        scenarioContext = _scenarioContext;
        skill = "";
        addedUserSkill = false;
        elementInteractions = new CommonSendKeysAndClick(scenarioContext);
        driver = (IWebDriver)scenarioContext["driver"];
    }

    public void ClickOnSkillsTab()
    {
        elementInteractions.ClickOnElement(skillsBtn);
    }

    public void ClickOnAddNewBtn()
    {
        elementInteractions.ReturnAllElementsByLocator(addNewBtn)[1].Click();
    }

    public void NewSkillInputBox(string skill)
    {
        elementInteractions.SendKeysTolement(skillInputBox, skill);
    }

    public void SelectSkillLevel(string level)
    {
        skillLevelDropDownListBox=new SelectElement(elementInteractions.ReturnElement(skillLevelDropdown));
        skillLevelDropDownListBox.SelectByText(level);
    }

    public void ClickOnAddBtn()
    {
        elementInteractions.ClickOnElement(addBtn);
    }

    public void GetAllColumnsFromSkillRows()
    {
        webElements = elementInteractions.ReturnAllElementsByLocator(allColumnsInSkillRows);
    }

    public void AddNewUserSkill(string userSkill, string skillLevel)
    {
        ClickOnSkillsTab();
        ClickOnAddNewBtn();
        NewSkillInputBox(userSkill);
        SelectSkillLevel(skillLevel);
        ClickOnAddBtn();
        CheckSkillAddedToUser();
    }
    public void CheckSkillAddedToUser()
    {
        //checking all the columns for added language
        GetAllColumnsFromSkillRows();
        for (int i = 0; i < webElements.Count; i++)
        {
            if (webElements[i].Text.Equals(skill) && i < webElements.Count - 1)
            {
                addedUserSkill = true;
                break;
            }
        }
    }

    public void SkillAddedAssertion()
    {
        addedUserSkill.Should().BeTrue();
    }
}
