
namespace MarsOnBoarding;

[Binding]
public sealed class PortalLogInStepDefinition
{
    private CommonDriver? pl;
    private ScenarioContext? scenarioContext;
    private LoginToPortalPage LTPP;

    public PortalLogInStepDefinition(ScenarioContext _scenarioContext )
    {
        pl = new();
        scenarioContext = _scenarioContext;
        scenarioContext.Add("driver", pl.Driver);
        scenarioContext.Add("CommonDriver", pl);
        LTPP = new(scenarioContext);
    }
    
    [Given(@"User logs in to the website")]
    public void GivenUserLogsInToTheWebsite()
    {
        LTPP.LogintoPortal();
    }

 }