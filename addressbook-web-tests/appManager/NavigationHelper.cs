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
        driver.Navigate().GoToUrl(baseURL + "/addressbook/group.php");
    }

    public void GoToGroupsPage()
    {
        driver.FindElement(By.LinkText("groups")).Click();
    }
}