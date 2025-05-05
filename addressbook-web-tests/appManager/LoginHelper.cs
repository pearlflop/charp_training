using OpenQA.Selenium;

namespace WebAddressBookTests;

public class LoginHelper : HelperBase
{
    public LoginHelper(ApplicationManager manager) : base(manager)
    {
    }

    public void Login(AccountData account)
    {
        if (isLoggedIn())
        {
            if (isLoggedIn(account))
            {
                return;
            }

            Logout();
        }

        Type(By.Name("user"), account.Username);
        Type(By.Name("pass"), account.Password);
        driver.FindElement(By.XPath("//input[@value='Login']")).Click();
    }

    public void Logout()
    {
        if (isLoggedIn())
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }
    }

    public bool isLoggedIn()
    {
        return IsElementPresent(By.Name("logout"));
    }


    public bool isLoggedIn(AccountData account)
    {
        return isLoggedIn() && driver.FindElement(By.Name("logout"))
            .FindElement(By.TagName("b")).Text == "(" + account.Username + ")";
    }
}