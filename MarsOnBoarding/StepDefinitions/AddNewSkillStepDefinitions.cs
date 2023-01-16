namespace MarsOnBoarding;
[Binding]
public class AddNewSkillStepDefinitions
{
    private readonly AddNewSkillPage ANSP;
    private ScenarioContext scenarioContext;
    public AddNewSkillStepDefinitions(ScenarioContext _scenarioContext)
    {
        scenarioContext = _scenarioContext;
        ANSP=new AddNewSkillPage(scenarioContext);
    }
    [When(@"User adds a '([^']*)' and a '([^']*)'")]
    public void WhenUserAddsANewSkill(string userSkill, string skillLevel)
    {
        ANSP.AddNewUserSkill(userSkill, skillLevel);
    }

    [Then(@"the skill is added successfully on the user profile")]
    public void ThenTheSkillIsAddedSuccessfullyOnTheUserProfile()
    {
        ANSP.SkillAddedAssertion();
    }

}
