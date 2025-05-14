using OpenQA.Selenium;

namespace WebAddressBookTests;

public class NavigationHelper : HelperBase
{
    private string baseURL;

    public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
    {
        this.baseURL = baseURL;
    }

    public void OpenHomePage()
    {
        if (driver.Url == baseURL + "/addressbook/")
        {
            return;
        }

        driver.Navigate().GoToUrl(baseURL + "/addressbook/");
    }

    public void GoToGroupsPage()
    {
        if (driver.Url == baseURL + "/addressbook/groups.php" && IsElementPresent(By.Name("new")))
        {
            return;
        }

        driver.FindElement(By.LinkText("groups")).Click();
    }

    public void GoToContactPage()
    {
        driver.FindElement(By.LinkText("add new")).Click();
    }

    public void GoToHomePage()
    {
        driver.FindElement(By.LinkText("home")).Click();
        driver.Navigate().GoToUrl("http://localhost/addressbook/");
    }
}