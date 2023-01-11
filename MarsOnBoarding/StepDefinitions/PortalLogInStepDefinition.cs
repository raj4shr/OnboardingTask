
namespace MarsOnBoarding;

[Binding]
public sealed class PortalLogInStepDefinition
{
    private CommonDriver? pl;
    private ScenarioContext? scenarioContext;

    public PortalLogInStepDefinition(ScenarioContext _scenarioContext )
    {
        pl = new();
        scenarioContext = _scenarioContext;
        scenarioContext.Add("driver", pl.Driver);
        scenarioContext.Add("CommonDriver", pl);
    }
    
    [Given(@"User logs in to the website")]
    public void GivenUserLogsInToTheWebsite()
    {
        pl.LogintoPortal();
    }

 }