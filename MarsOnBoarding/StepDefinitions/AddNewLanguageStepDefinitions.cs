
namespace MarsOnBoarding;
[Binding]
public class AddNewLanguageStepDefinitions 
{
    private readonly AddNewLanguagePage _addNewLanguagePage;
    private ScenarioContext? scenarioContext;

    public AddNewLanguageStepDefinitions(ScenarioContext _scenarioContext)
    {
        scenarioContext = _scenarioContext;
        _addNewLanguagePage=new AddNewLanguagePage(scenarioContext);
    }

    [When(@"User adds a language")]
    public void WhenUserAddsALanguage()
    {
        _addNewLanguagePage.AddNewUserLanguage();
    }
    [Then(@"the language is updated successfully on the user profile")]
    public void ThenTheLanguageIsUpdatedSuccessfullyOnTheUserProfile()
    {
        _addNewLanguagePage.CheckLanguageAddedToUser();
        _addNewLanguagePage.LanguageAddedAssertion();
    }

}
