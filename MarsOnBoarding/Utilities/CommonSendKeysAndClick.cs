
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

    public void sendKeysToElement(string elementLocator,string locatorValue,string elementValue)
    {
        if(elementLocator.ToUpper().Equals("ID"))
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(locatorValue)));
            element = driver.FindElement(By.Id(locatorValue));
            element.Clear();
            element.SendKeys(elementValue);
        }
        else if (elementLocator.ToUpper().Equals("NAME"))
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name(locatorValue)));
            element = driver.FindElement(By.Name(locatorValue));
            element.Clear();
            element.SendKeys(elementValue);
        }
        else if (elementLocator.ToUpper().Equals("CLASSNAME"))
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(locatorValue)));
            element = driver.FindElement(By.ClassName(locatorValue));
            element.Clear();
            element.SendKeys(elementValue);
        }
        else if (elementLocator.ToUpper().Equals("XPATH"))
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locatorValue)));
            element = driver.FindElement(By.XPath(locatorValue));
            element.Clear();
            element.SendKeys(elementValue);
        }
        else if (elementLocator.ToUpper().Equals("TAGNAME"))
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.TagName(locatorValue)));
            element = driver.FindElement(By.TagName(locatorValue));
            element.Clear();
            element.SendKeys(elementValue);
        }
        else if (elementLocator.ToUpper().Equals("CSSSELECTOR"))
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(locatorValue)));
            element = driver.FindElement(By.CssSelector(locatorValue));
            element.SendKeys(elementValue);
        }
        else if (elementLocator.ToUpper().Equals("LINKTEXT"))
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(locatorValue)));
            element = driver.FindElement(By.LinkText(locatorValue));
            element.Clear();
            element.SendKeys(elementValue);
        }
        else if (elementLocator.ToUpper().Equals("PARTIALLINKTEXT"))
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.PartialLinkText(locatorValue)));
            element = driver.FindElement(By.PartialLinkText(locatorValue));
            element.Clear();
            element.SendKeys(elementValue);
        }
    }

    public void clickOnElement(string elementLocator, string locatorValue)
    {
        if (elementLocator.ToUpper().Equals("ID"))
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(locatorValue)));
            element = driver.FindElement(By.Id(locatorValue));
            element.Click();
        }
        else if (elementLocator.ToUpper().Equals("NAME"))
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Name(locatorValue)));
            element = driver.FindElement(By.Name(locatorValue));
            element.Click();
        }
        else if (elementLocator.ToUpper().Equals("CLASSNAME"))
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName(locatorValue)));
            element = driver.FindElement(By.ClassName(locatorValue));
            element.Click();
        }
        else if (elementLocator.ToUpper().Equals("XPATH"))
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(locatorValue)));
            element = driver.FindElement(By.XPath(locatorValue));
            element.Click();
        }
        else if (elementLocator.ToUpper().Equals("TAGNAME"))
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.TagName(locatorValue)));
            element = driver.FindElement(By.TagName(locatorValue));
            element.Click();
        }
        else if (elementLocator.ToUpper().Equals("CSSSELECTOR"))
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(locatorValue)));
            element = driver.FindElement(By.CssSelector(locatorValue));
            element.Click();
        }
        else if (elementLocator.ToUpper().Equals("LINKTEXT"))
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText(locatorValue)));
            element = driver.FindElement(By.LinkText(locatorValue));
            element.Click();
        }
        else if (elementLocator.ToUpper().Equals("PARTIALLINKTEXT"))
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.PartialLinkText(locatorValue)));
            element = driver.FindElement(By.PartialLinkText(locatorValue));
            element.Click();
        }
    }

    public string getElementText(string elementLocator,string locatorValue)
    {
        string elementText = "";
        if (elementLocator.ToUpper().Equals("ID"))
        {
            wait.Until(ExpectedConditions.ElementToBeSelected(By.Id(locatorValue)));
            element = driver.FindElement(By.Id(locatorValue));
            elementText=element.Text;
        }
        else if (elementLocator.ToUpper().Equals("NAME"))
        {
            wait.Until(ExpectedConditions.ElementToBeSelected(By.Name(locatorValue)));
            element = driver.FindElement(By.Name(locatorValue));
            elementText = element.Text;
        }
        else if (elementLocator.ToUpper().Equals("CLASSNAME"))
        {
            wait.Until(ExpectedConditions.ElementToBeSelected(By.ClassName(locatorValue)));
            element = driver.FindElement(By.ClassName(locatorValue));
            elementText = element.Text;
        }
        else if (elementLocator.ToUpper().Equals("XPATH"))
        {
            wait.Until(ExpectedConditions.ElementToBeSelected(By.XPath(locatorValue)));
            element = driver.FindElement(By.XPath(locatorValue));
            elementText = element.Text;
        }
        else if (elementLocator.ToUpper().Equals("TAGNAME"))
        {
            wait.Until(ExpectedConditions.ElementToBeSelected(By.TagName(locatorValue)));
            element = driver.FindElement(By.TagName(locatorValue));
            elementText = element.Text;
        }
        else if (elementLocator.ToUpper().Equals("CSSSELECTOR"))
        {
            wait.Until(ExpectedConditions.ElementToBeSelected(By.CssSelector(locatorValue)));
            element = driver.FindElement(By.CssSelector(locatorValue));
            elementText = element.Text;
        }
        else if (elementLocator.ToUpper().Equals("LINKTEXT"))
        {
            wait.Until(ExpectedConditions.ElementToBeSelected(By.LinkText(locatorValue)));
            element = driver.FindElement(By.LinkText(locatorValue));
            elementText = element.Text;
        }
        else if (elementLocator.ToUpper().Equals("PARTIALLINKTEXT"))
        {
            wait.Until(ExpectedConditions.ElementToBeSelected(By.PartialLinkText(locatorValue)));
            element = driver.FindElement(By.PartialLinkText(locatorValue));
            elementText = element.Text;
        }
        return elementText;
     }

    public ReadOnlyCollection<IWebElement> findElementsByLocator(string elementLocator,string locatorValue)
    {
        if (elementLocator.ToUpper().Equals("ID"))
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id(locatorValue)));
            elements = driver.FindElements(By.Id(locatorValue));
        }
        else if (elementLocator.ToUpper().Equals("NAME"))
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name(locatorValue)));
            elements = driver.FindElements(By.Name(locatorValue));
        }
        else if (elementLocator.ToUpper().Equals("CLASSNAME"))
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(locatorValue)));
            elements = driver.FindElements(By.Id(locatorValue));
        }
        else if (elementLocator.ToUpper().Equals("XPATH"))
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(locatorValue)));
            elements = driver.FindElements(By.XPath(locatorValue));
        }
        else if (elementLocator.ToUpper().Equals("TAGNAME"))
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.TagName(locatorValue)));
            elements = driver.FindElements(By.TagName(locatorValue));
        }
        else if (elementLocator.ToUpper().Equals("CSSSELECTOR"))
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(locatorValue)));
            elements = driver.FindElements(By.CssSelector(locatorValue));
        }
        else if (elementLocator.ToUpper().Equals("LINKTEXT"))
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(locatorValue)));
            elements = driver.FindElements(By.LinkText(locatorValue));
        }
        else if (elementLocator.ToUpper().Equals("PARTIALLINKTEXT"))
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.PartialLinkText(locatorValue)));
            elements = driver.FindElements(By.PartialLinkText(locatorValue));
        }
        return elements;
    }

    public ReadOnlyCollection<IWebElement> findElementsByLocatorElementExits(string elementLocator, string locatorValue)
    {
        if (elementLocator.ToUpper().Equals("ID"))
        {
            wait.Until(ExpectedConditions.ElementExists(By.Id(locatorValue)));
            elements = driver.FindElements(By.Id(locatorValue));
        }
        else if (elementLocator.ToUpper().Equals("NAME"))
        {
            wait.Until(ExpectedConditions.ElementExists(By.Name(locatorValue)));
            elements = driver.FindElements(By.Name(locatorValue));
        }
        else if (elementLocator.ToUpper().Equals("CLASSNAME"))
        {
            wait.Until(ExpectedConditions.ElementExists(By.ClassName(locatorValue)));
            elements = driver.FindElements(By.Id(locatorValue));
        }
        else if (elementLocator.ToUpper().Equals("XPATH"))
        {
            wait.Until(ExpectedConditions.ElementExists(By.XPath(locatorValue)));
            elements = driver.FindElements(By.XPath(locatorValue));
        }
        else if (elementLocator.ToUpper().Equals("TAGNAME"))
        {
            wait.Until(ExpectedConditions.ElementExists(By.TagName(locatorValue)));
            elements = driver.FindElements(By.TagName(locatorValue));
        }
        else if (elementLocator.ToUpper().Equals("CSSSELECTOR"))
        {
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector(locatorValue)));
            elements = driver.FindElements(By.CssSelector(locatorValue));
        }
        else if (elementLocator.ToUpper().Equals("LINKTEXT"))
        {
            wait.Until(ExpectedConditions.ElementExists(By.LinkText(locatorValue)));
            elements = driver.FindElements(By.LinkText(locatorValue));
        }
        else if (elementLocator.ToUpper().Equals("PARTIALLINKTEXT"))
        {
            wait.Until(ExpectedConditions.ElementExists(By.PartialLinkText(locatorValue)));
            elements = driver.FindElements(By.PartialLinkText(locatorValue));
        }
        return elements;
    }
}
