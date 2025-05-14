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

    public ContactHelper Remove(int i, ContactData contact)
    {
        manager.Navigation.GoToHomePage();
        if (IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + i + "]")) == false)
        {
            Create(contact);
        }

        SelectContact(i, contact);
        RemoveContact();
        ReturnToHomePage();
        return this;
    }

    public ContactHelper Modify(int i, ContactData newData, ContactData contact)
    {
        manager.Navigation.GoToHomePage();
        if (IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + i + "]")) == false)
        {
            Create(contact);
        }

        EditContactPage(i);
        FillContactForm(newData);
        SubmitContactModification();
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
        Type(By.Name("firstname"), contact.FirstName);
        Type(By.Name("lastname"), contact.LastName);
        return this;
    }

    private ContactHelper SelectContact(int index, ContactData contact)
    {
        driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
        return this;
    }

    private ContactHelper RemoveContact()
    {
        driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
        return this;
    }

    private ContactHelper SubmitContactModification()
    {
        driver.FindElement(By.Name("update")).Click();
        return this;
    }

    public ContactHelper EditContactPage(int index)
    {
        driver.Navigate().GoToUrl("http://localhost/addressbook/edit.php?id=" + index + "");
        return this;
    }
}