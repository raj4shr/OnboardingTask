
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

   


    [When(@"User adds a '([^']*)' and '([^']*)'")]
    public void WhenNewUserLangaugeIsAdded(string language, string languageLevel)
    {
        _addNewLanguagePage.AddNewUserLanguage(language, languageLevel);
    }

    [Then(@"the user language is added successfully on the user profile")]
    public void ThenTheUserLanguageIsAddedSuccessfullyOnTheUserProfile()
    {
        _addNewLanguagePage.LanguageAddedAssertion();
    }
}
