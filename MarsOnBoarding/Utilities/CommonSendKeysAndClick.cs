
namespace MarsOnBoarding;

public class CommonSendKeysAndClick
{
    private ReadOnlyCollection<IWebElement>? elements;
    private IWebDriver driver;
    private IWebElement? element;
    private ScenarioContext? scenarioContext;
    WebDriverWait wait;

    public CommonSendKeysAndClick(ScenarioContext _scenarioContext)
    {
        scenarioContext=_scenarioContext;
        driver = (IWebDriver)scenarioContext["driver"];
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
    }

    public void ClickOnElement(By elementLocator)
    {
        wait.Until(ExpectedConditions.ElementIsVisible(elementLocator));    
        driver.FindElement(elementLocator).Click();
    }

    public void SendKeysTolement(By elementLocator,string elementValue)
    {
        wait.Until(ExpectedConditions.ElementIsVisible(elementLocator));
        driver.FindElement(elementLocator).Clear();
        driver.FindElement(elementLocator).SendKeys(elementValue);
    }

    public IWebElement ReturnElement(By elementLocator)
    {
        wait.Until(ExpectedConditions.ElementIsVisible(elementLocator));
        return driver.FindElement(elementLocator);
    }

    public ReadOnlyCollection<IWebElement> ReturnAllElementsByLocator(By elementLocator)
    {
        wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(elementLocator));
        return driver.FindElements(elementLocator);
    }

    public void RefreshDriver()
    {
        driver.Navigate().Refresh();
    }
}
