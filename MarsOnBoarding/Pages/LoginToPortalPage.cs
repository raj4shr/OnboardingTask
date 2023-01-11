using OpenQA.Selenium;

namespace MarsOnBoarding;

public class LoginToPortalPage
{
    private IWebDriver? driver;
    private IWebElement? webElement;
    

    public void LogintoPortal(IWebDriver driver)
    {
        driver.Navigate().GoToUrl("http://localhost:5000/");
        driver.Manage().Window.Maximize();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        webElement = driver.FindElement(By.ClassName("item"));
        webElement.Click();
        EnterLoginDetails(driver);
    }

    public void EnterLoginDetails(IWebDriver driver)
    {
        webElement = driver.FindElement(By.Name("email"));
        webElement.SendKeys("raj4shr@gmail.com");
        webElement = driver.FindElement(By.Name("password"));
        webElement.SendKeys("IndustryConnect2023");
        webElement = driver.FindElement(By.XPath("//button[text()='Login']"));
        webElement.Click();

    }
}
