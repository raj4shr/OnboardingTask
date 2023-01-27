using OpenQA.Selenium;

namespace MarsOnBoarding;

public class LoginToPortalPage
{
    private IWebDriver driver;
    private IWebElement? webElement;
    private ScenarioContext scenarioContext;
    private CommonSendKeysAndClick findElements;

    public LoginToPortalPage(ScenarioContext _scenarioContext)
    {
        scenarioContext = _scenarioContext;
        driver = (IWebDriver)scenarioContext["driver"];
        findElements=new CommonSendKeysAndClick(scenarioContext);
    }

    public void LogintoPortal()
    {
        driver.Navigate().GoToUrl("http://localhost:5000/");
        driver.Manage().Window.Maximize();
        findElements.clickOnElement(nameof(By.ClassName), "item");
        EnterLoginDetails();
    }

    public void EnterLoginDetails()
    {
        findElements.sendKeysToElement(nameof(By.Name), "email", "raj4shr@gmail.com");
        findElements.sendKeysToElement(nameof(By.Name), "password", "IndustryConnect2023");
        findElements.clickOnElement(nameof(By.XPath), "//button[text()='Login']");
    }
}
