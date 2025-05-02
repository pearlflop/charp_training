using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebAddressBookTests;

public class ApplicationManager
{
    public IWebDriver driver;
    protected string baseURL;

    protected LoginHelper loginHelper;
    protected NavigationHelper navigation;
    protected GroupHelper groupHelper;

    public ApplicationManager()
    {
        driver = new ChromeDriver();
        baseURL = "http://localhost";

        loginHelper = new LoginHelper(this);
        navigation = new NavigationHelper(this, baseURL);
        groupHelper = new GroupHelper(this);
    }

    public IWebDriver Driver
    {
        get { return driver; }
    }

    public void Stop()
    {
        try
        {
            driver.Quit();
        }
        catch (Exception)
        {
            // Ignore errors if unable to close the browser
        }
    }

    public LoginHelper Auth
    {
        get { return loginHelper; }
    }

    public NavigationHelper Navigation
    {
        get { return navigation; }
    }

    public GroupHelper Groups
    {
        get { return groupHelper; }
    }
}