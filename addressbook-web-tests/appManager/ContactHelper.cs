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
        manager.Navigation.GoToHomePage();
        return this;
    }

    public ContactHelper Remove(int i)
    {
        SelectContact(i);
        RemoveContact();
        manager.Navigation.GoToHomePage();
        return this;
    }

    public ContactHelper Modify(int i, ContactData newData)
    {
        EditContactPage(i);
        FillContactForm(newData);
        SubmitContactModification();
        manager.Navigation.GoToHomePage();
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

    private ContactHelper SelectContact(int index)
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