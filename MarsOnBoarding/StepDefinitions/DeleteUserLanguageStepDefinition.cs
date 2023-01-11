﻿
namespace MarsOnBoarding;
[Binding]
public class DeleteUserLanguageStepDefinition
{
    private ScenarioContext scenarioContext;
    private readonly DeleteUserLanguagePage DLP;

    public DeleteUserLanguageStepDefinition(ScenarioContext _scenarioContext)
    {
        scenarioContext = _scenarioContext;
        DLP = new(scenarioContext);
    }

    [When(@"User deletes a language")]
    public void WhenUserDeletesALanguage()
    {
        DLP.CheckLanguageExists();
        DLP.DeleteUserLanguage();
    }

    [Then(@"The language is deleted successfully from the user profile")]
    public void ThenTheLanguageIsDeletedSuccessfullyFromTheUserProfile()
    {
        DLP.DeleteLanguageAssertion();
    }

}
