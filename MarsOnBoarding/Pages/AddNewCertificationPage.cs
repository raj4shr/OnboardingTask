
using OpenQA.Selenium.Support.UI;

namespace MarsOnBoarding;

public class AddNewCertificationPage
{
    private readonly CommonSendKeysAndClick elementInteractions;
	private ScenarioContext scenarioContext;
    private string certification;
	private bool addedUserCertification;
	private ReadOnlyCollection<IWebElement>? webElements;
    private readonly IWebDriver driver;
    private SelectElement certificateYearOptionBox;

    private readonly By certificationsBtn = By.XPath("//a[text()='Certifications']");
    private readonly By addNewCerticationsBtn = By.XPath("//div[text()='Add New']");
    private readonly By newCertificateInputBox = By.XPath("//input[@placeholder='Certificate or Award']");
    private readonly By certificateFromInputBox = By.XPath("//input[@placeholder='Certified From (e.g. Adobe)']");
    private readonly By certificationYear = By.Name("certificationYear");
    private readonly By addBtn = By.XPath("//input[@value='Add']");
    private readonly By certificationRowsColumns = By.TagName("td");


    public void ClickOnCertificationsBtn()
    {
        elementInteractions.ClickOnElement(certificationsBtn);
    }

    public void ClickOnAddNewBtn()
    {
        elementInteractions.ReturnAllElementsByLocator(addNewCerticationsBtn)[3].Click();
    }

    public void InputNewCertificate(string certificate)
    {
        elementInteractions.SendKeysTolement(newCertificateInputBox, certificate);  
    }

    public void InputCertificationFrom(string certificationFrom)
    {
        elementInteractions.SendKeysTolement(certificateFromInputBox, certificationFrom);
    }

    public void SelectCertificateYear(string certYear)
    {
        certificateYearOptionBox=new SelectElement(elementInteractions.ReturnElement(certificationYear));
        certificateYearOptionBox.SelectByText(certYear);
    }

    public void ClickOnAddBtn()
    {
        elementInteractions.ClickOnElement(addBtn);
    }

    public void GetAllCertificationRows()
    {
        webElements= elementInteractions.ReturnAllElementsByLocator(certificationRowsColumns);
    }
    public AddNewCertificationPage(ScenarioContext _scenarioContext)
	{
		scenarioContext = _scenarioContext;
        elementInteractions = new CommonSendKeysAndClick(scenarioContext);
		certification  = "";
		addedUserCertification = false;
        driver = (IWebDriver)scenarioContext["driver"];
    }


    public void AddNewUserCertification(string userCertificate, string certificateFrom,string certificateYear)
    {
        certification = userCertificate;
        ClickOnCertificationsBtn();
        ClickOnAddNewBtn();
        InputNewCertificate(userCertificate);
        InputCertificationFrom(certificateFrom);
        SelectCertificateYear(certificateYear);
        ClickOnAddBtn();
        CheckCertificationAddedToUser();
    }
    public void CheckCertificationAddedToUser()
    {
        ClickOnCertificationsBtn();
        GetAllCertificationRows();
        //checking all the columns for added language
        for (int i = 0; i < webElements.Count; i++)
        {
            if (webElements[i].Text.Equals(certification) && i < webElements.Count)
            {
                addedUserCertification = true;
                break;
            }
        }
    }

    public void CertificationAddedAssertion()
    {
        addedUserCertification.Should().BeTrue();
    }
}
