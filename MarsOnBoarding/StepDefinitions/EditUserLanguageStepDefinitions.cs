
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

    [When(@"User updates a '([^']*)' to '([^']*)' and '([^']*)'")]
    public void WhenUserUpdatesALanguage(string language, string updatedLanguage, string updatedLanguageLevel)
    {
        EULP.EditUserLanguage(language,updatedLanguage,updatedLanguageLevel);
    }

    [Then(@"The language is updated successfully on the user profile")]
    public void ThenTheLanguageIsUpdatedSuccessfullyOnTheUserProfile()
    {
        EULP.UpdateAssertion();
    }

}
