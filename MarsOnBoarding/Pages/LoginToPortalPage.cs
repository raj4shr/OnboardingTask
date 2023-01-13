using OpenQA.Selenium;

namespace MarsOnBoarding;

public class LoginToPortalPage
{
    private IWebDriver? driver;
    private IWebElement? webElement;
    private ScenarioContext scenarioContext;

    public LoginToPortalPage(ScenarioContext _scenarioContext)
    {
        scenarioContext = _scenarioContext;
        driver = (IWebDriver)scenarioContext["driver"];
    }

    public void LogintoPortal()
    {
        driver.Navigate().GoToUrl("http://localhost:5000/");
        driver.Manage().Window.Maximize();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        webElement = driver.FindElement(By.ClassName("item"));
        webElement.Click();
        EnterLoginDetails();
    }

    public void EnterLoginDetails()
    {
        webElement = driver.FindElement(By.Name("email"));
        webElement.SendKeys("raj4shr@gmail.com");
        webElement = driver.FindElement(By.Name("password"));
        webElement.SendKeys("IndustryConnect2023");
        webElement = driver.FindElement(By.XPath("//button[text()='Login']"));
        webElement.Click();

    }
}
