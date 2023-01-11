

using TechTalk.SpecFlow;

namespace MarsOnBoarding;
[Binding]
public class Hooks
{
    private ScenarioContext scenarioContext;
    private readonly CommonDriver cd;
    public Hooks(ScenarioContext _scenarioContext)
    {
        scenarioContext = _scenarioContext;
        cd = (CommonDriver)scenarioContext["CommonDriver"];
    }

    [AfterScenario]
    public void ShutDownDriver()
    {
        scenarioContext.Clear();
        cd.Driver.Quit();
    }
}
