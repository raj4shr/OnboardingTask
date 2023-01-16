
namespace MarsOnBoarding;

public class AddNewSkillPage
{
    private ReadOnlyCollection<IWebElement>? webElements;
    private ScenarioContext scenarioContext;
    private readonly string skill;
    private readonly string skillLevel;
    private bool addedUserSkill;
    private int rowIndex;
    private readonly CommonSendKeysAndClick findElements;

    public AddNewSkillPage(ScenarioContext _scenarioContext)
    {
        scenarioContext = _scenarioContext;
        skill = "";
        skillLevel = "";
        addedUserSkill = false;
        rowIndex = -1;
        findElements = new CommonSendKeysAndClick(scenarioContext);
    }

    public void AddNewUserSkill(string userSkill, string skillLevel)
    {
        findElements.clickOnElement(nameof(By.XPath), "//a[text()='Skills']");
        findElements.clickOnElement(nameof(By.XPath), "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div");
        findElements.sendKeysToElement(nameof(By.XPath), "//input[@placeholder='Add Skill']", userSkill);
        findElements.clickOnElement(nameof(By.XPath), "//select[@name='level']");
        findElements.clickOnElement(nameof(By.XPath),"//option[@value='" + skillLevel + "']");
        findElements.clickOnElement(nameof(By.XPath), "//input[@value='Add']");
        CheckSkillAddedToUser();
    }
    public void CheckSkillAddedToUser()
    {
        //checking all the columns for added language
        webElements = findElements.findElementsByLocatorElementExits(nameof(By.TagName), "td");
        for (int i = 0; i < webElements.Count; i++)
        {
            if (webElements[i].Text.Equals(skill) && i < webElements.Count - 1)
            {
                rowIndex = i;
                if (webElements[i + 1].Text.Equals(skillLevel))
                {
                    addedUserSkill = true;
                    break;
                }
            }
        }
    }

    public void SkillAddedAssertion()
    {
        addedUserSkill.Should().BeTrue();
    }
}
