using OpenQA.Selenium;

namespace MarsOnBoarding;

public class LoginToPortalPage
{
    private IWebDriver driver;
    private IWebElement? webElement;
    private ScenarioContext scenarioContext;
    private CommonSendKeysAndClick elementInteractions;

    private readonly By signInBtn = By.ClassName("item");
    private readonly By emailInputBox = By.Name("email");
    private readonly By passwordInputBox = By.Name("password");
    private readonly By loginBtn = By.XPath("//button[text()='Login']");

    public LoginToPortalPage(ScenarioContext _scenarioContext)
    {
        scenarioContext = _scenarioContext;
        driver = (IWebDriver)scenarioContext["driver"];
        elementInteractions = new CommonSendKeysAndClick(scenarioContext);
    }

    public void InputEmail()
    {
        elementInteractions.SendKeysTolement(emailInputBox, "raj4shr@gmail.com");
    }

    public void InputPassword()
    {
        elementInteractions.SendKeysTolement(passwordInputBox, "IndustryConnect2023");
    }

    public void ClickOnLoginBtn()
    {
        elementInteractions.ClickOnElement(loginBtn);
    }

    public void ClickOnSignIn()
    {
        elementInteractions.ClickOnElement(signInBtn);
    }
    public void LogintoPortal()
    {
        driver.Navigate().GoToUrl("http://localhost:5000/");
        driver.Manage().Window.Maximize();
        ClickOnSignIn();
        EnterLoginDetails();
    }

    public void EnterLoginDetails()
    {
        InputEmail();
        InputPassword();
        ClickOnLoginBtn();
    }
}
