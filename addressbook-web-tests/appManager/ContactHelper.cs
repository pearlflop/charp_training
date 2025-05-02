using OpenQA.Selenium;

namespace WebAddressBookTests;

public class ContactHelper : HelperBase
{
    public ContactHelper(ApplicationManager manager) : base(manager)
    {
    }

    public ContactHelper Create(ContactData contact)
    {
        manager.Navigation.GoToContactPage();

        FillContactForm(contact);
        SubmitContactCreation();
        ReturnToHomePage();
        return this;
    }

    private ContactHelper ReturnToHomePage()
    {
        driver.FindElement(By.LinkText("home")).Click();
        driver.Navigate().GoToUrl("http://localhost/addressbook/");
        return this;
    }

    private ContactHelper SubmitContactCreation()
    {
        driver.FindElement(By.XPath("//input[20]")).Click();
        driver.Navigate().GoToUrl("http://localhost/addressbook/");
        return this;
    }

    private ContactHelper FillContactForm(ContactData contact)
    {
        driver.FindElement(By.Name("firstname")).Click();
        driver.FindElement(By.Name("firstname")).Clear();
        driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);
        driver.FindElement(By.Name("lastname")).Click();
        driver.FindElement(By.Name("lastname")).Clear();
        driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
        return this;
    }
}