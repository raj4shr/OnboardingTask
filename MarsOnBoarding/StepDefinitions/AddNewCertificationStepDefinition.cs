
namespace MarsOnBoarding;
[Binding]
public class AddNewCertificationStepDefinition
{
    private ScenarioContext scenarioContext;
    private readonly AddNewCertificationPage ANCP;

    public AddNewCertificationStepDefinition(ScenarioContext _scenarioContext)
    {
        scenarioContext = _scenarioContext;
        ANCP = new AddNewCertificationPage(scenarioContext);
    }

    [When(@"User adds a '([^']*)', '([^']*)' and '([^']*)'")]
    public void WhenUserAddsANewCertificate(string userCertificate, string certificateFrom, string certificateYear)
    {
        ANCP.AddNewUserCertification(userCertificate, certificateFrom, certificateYear);
    }
    [Then(@"the certification is added successfully on the user profile")]
    public void ThenTheCertificationIsAddedSuccessfullyOnTheUserProfile()
    {
        ANCP.CertificationAddedAssertion();
    }


}
