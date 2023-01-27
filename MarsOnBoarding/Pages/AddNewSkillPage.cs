
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
    private readonly IWebDriver driver;
    private WebDriverWait wait;

    public AddNewSkillPage(ScenarioContext _scenarioContext)
    {
        scenarioContext = _scenarioContext;
        skill = "";
        skillLevel = "";
        addedUserSkill = false;
        rowIndex = -1;
        findElements = new CommonSendKeysAndClick(scenarioContext);
        driver = (IWebDriver)scenarioContext["driver"];
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
    }

    public void AddNewUserSkill(string userSkill, string skillLevel)
    {
        findElements.clickOnElement(nameof(By.XPath), "//a[text()='Skills']");

        wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//div[text()='Add New']")));
        webElements = driver.FindElements(By.XPath("//div[text()='Add New']"));
        webElements[1].Click();
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
