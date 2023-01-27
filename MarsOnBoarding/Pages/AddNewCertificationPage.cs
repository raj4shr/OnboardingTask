
using OpenQA.Selenium.Support.UI;

namespace MarsOnBoarding;

public class AddNewCertificationPage
{
    private readonly CommonSendKeysAndClick findElements;
	private ScenarioContext scenarioContext;
	private string certification, certificationFrom;
	private int rowIndex;
	private bool addedUserCertification;
	private ReadOnlyCollection<IWebElement>? webElements;
    private readonly IWebDriver driver;
    private WebDriverWait wait;

    public AddNewCertificationPage(ScenarioContext _scenarioContext)
	{
		scenarioContext = _scenarioContext;
		findElements=new CommonSendKeysAndClick(scenarioContext);
		rowIndex = -1;
		certification = certificationFrom = "";
		addedUserCertification = false;
        driver = (IWebDriver)scenarioContext["driver"];
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
    }


    public void AddNewUserCertification(string userCertificate, string certificateFrom,string certificateYear)
    {
        certification = userCertificate;
        certificationFrom = certificateFrom;
        findElements.clickOnElement(nameof(By.XPath), "//a[text()='Certifications']");
        wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//div[text()='Add New']")));
        webElements = driver.FindElements(By.XPath("//div[text()='Add New']"));
        webElements[3].Click();
        //findElements.clickOnElement(nameof(By.XPath), "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div");
        findElements.sendKeysToElement(nameof(By.XPath), "//input[@placeholder='Certificate or Award']", userCertificate);
        findElements.sendKeysToElement(nameof(By.XPath), "//input[@placeholder='Certified From (e.g. Adobe)']", certificateFrom);
        findElements.clickOnElement(nameof(By.Name), "certificationYear");
        findElements.clickOnElement(nameof(By.XPath), "//option[@value='" + certificateYear + "']");
        findElements.clickOnElement(nameof(By.XPath), "//input[@value='Add']");
        Thread.Sleep(2000);
        CheckCertificationAddedToUser();
    }
    public void CheckCertificationAddedToUser()
    {
        //checking all the columns for added language
        webElements = findElements.findElementsByLocatorElementExits(nameof(By.TagName), "td");
        for (int i = 0; i < webElements.Count; i++)
        {
            if (webElements[i].Text.Equals(certification) && i < webElements.Count)
            {
                rowIndex = i;
                if (webElements[i + 1].Text.Equals(certificationFrom))
                {
                    addedUserCertification = true;
                    break;
                }
            }
        }
    }

    public void CertificationAddedAssertion()
    {
        addedUserCertification.Should().BeTrue();
    }
}
