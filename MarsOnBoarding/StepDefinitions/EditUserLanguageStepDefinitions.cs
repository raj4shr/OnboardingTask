
namespace MarsOnBoarding;
[Binding]
public class EditUserLanguageStepDefinitions
{
    private ScenarioContext scenarioContext;
    private readonly EditUserLanguagePage EULP;
    public EditUserLanguageStepDefinitions(ScenarioContext _scenarioContext)
    {
        scenarioContext = _scenarioContext;
        EULP = new EditUserLanguagePage(scenarioContext);
    }

    [When(@"User updates a language")]
    public void WhenUserUpdatesALanguage()
    {
        EULP.EditUserLanguage();
    }
    [Then(@"The language is updated successfully on the user profile")]
    public void ThenTheLanguageIsUpdatedSuccessfullyOnTheUserProfile()
    {
        EULP.UpdateAssertion();
    }

}
