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
    protected ContactHelper contactHelper;
    private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

    private ApplicationManager()
    {
        driver = new ChromeDriver();
        baseURL = "http://localhost";

        loginHelper = new LoginHelper(this);
        navigation = new NavigationHelper(this, baseURL);
        groupHelper = new GroupHelper(this);
        contactHelper = new ContactHelper(this);
    }

    ~ApplicationManager()
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

    public static ApplicationManager GetInstance()
    {
        if (!app.IsValueCreated)
        {
            ApplicationManager newInstance = new ApplicationManager();
            newInstance.Navigation.OpenHomePage();
            app.Value = newInstance;
        }

        return app.Value;
    }

    public IWebDriver Driver
    {
        get { return driver; }
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

    public ContactHelper Contact

    {
        get { return contactHelper; }
    }
}