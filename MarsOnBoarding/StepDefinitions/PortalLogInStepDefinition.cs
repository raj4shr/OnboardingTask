
namespace MarsOnBoarding;

[Binding]
public sealed class PortalLogInStepDefinition
{
    private PortalLogin? pl;
    private ScenarioContext? scenarioContext;

    public PortalLogInStepDefinition(ScenarioContext _scenarioContext )
    {
        pl = new();
        scenarioContext = _scenarioContext;
        scenarioContext.Add("driver", pl.Driver);
    }
    
    [Given(@"User logs in to the website")]
    public void GivenUserLogsInToTheWebsite()
    {
        pl.LogintoPortal();
    }

    [AfterScenario]
    public void ShutDownDriver()
    {
        scenarioContext.Clear();
        pl.Driver.Quit();
    }

}