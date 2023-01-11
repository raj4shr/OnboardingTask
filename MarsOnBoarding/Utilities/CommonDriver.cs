global using TechTalk.SpecFlow;
global using FluentAssertions;
global using OpenQA.Selenium;
global using OpenQA.Selenium.Chrome;
global using System.Collections.ObjectModel;

namespace MarsOnBoarding;

public class CommonDriver
{
    private IWebDriver? driver;
    private IWebElement? webElement;
    
    public CommonDriver()
    {
        driver = new ChromeDriver();
    }

    public IWebDriver Driver 
    {
        get
        {
            return driver;
        }
       
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
