
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
        LTPP = new();
        scenarioContext = _scenarioContext;
        scenarioContext.Add("driver", pl.Driver);
        scenarioContext.Add("CommonDriver", pl);
    }
    
    [Given(@"User logs in to the website")]
    public void GivenUserLogsInToTheWebsite()
    {
        LTPP.LogintoPortal(pl.Driver);
    }

 }