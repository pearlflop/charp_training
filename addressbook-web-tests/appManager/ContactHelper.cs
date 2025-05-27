using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
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
        contactCache = null;
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
        contactCache = null;
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
        contactCache = null;
        return this;
    }

    public ContactHelper EditContactPage(int index)
    {
        ReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//tr[@name='entry']"));

        IWebElement row = rows[index];

        string contactId = row.FindElement(By.CssSelector("input[type='checkbox']")).GetAttribute("value");

        driver.Navigate().GoToUrl($"http://localhost/addressbook/edit.php?id={contactId}");

        return this;
    }

    private List<ContactData> contactCache = null;

    public List<ContactData> GetContactList()
    {
        if (contactCache == null)
        {
            contactCache = new List<ContactData>();

            manager.Navigation.GoToHomePage();
            ICollection<IWebElement> rows = driver.FindElements(By.XPath("//tr[@name='entry']"));
            foreach (IWebElement row in rows)
            {
                var elements = row.FindElements(By.TagName("td"));

                if (elements.Count >= 3)
                {
                    string lastName = elements[1].Text.Trim();
                    string firstName = elements[2].Text.Trim();

                    contactCache.Add(new ContactData(firstName, lastName)
                    {
                        Id = row.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }
        }

        return new List<ContactData>(contactCache);
    }

    public int GetContactCount()
    {
        return driver.FindElements(By.XPath("//tr[@name='entry']")).Count;
    }

    public ContactData GetContactInformationFromTable(int index)
    {
        manager.Navigation.GoToHomePage();

        IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
        string lastName = cells[1].Text;
        string firstName = cells[2].Text;
        string address = cells[3].Text;
        string allEmails = cells[4].Text;
        string allPhones = cells[5].Text;

        return new ContactData(firstName, lastName)
        {
            Address = address,
            AllPhones = allPhones,
            AllEmails = allEmails
        };
    }

    public ContactData GetContactInformationFromEditForm(int index)
    {
        manager.Navigation.GoToHomePage();
        EditContactPage(index);
        string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
        string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
        string address = driver.FindElement(By.Name("address")).GetAttribute("value");
        string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
        string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
        string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
        string email1 = driver.FindElement(By.Name("email")).GetAttribute("value");
        string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
        string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
        
        return new ContactData(firstName, lastName)
        {
            Address = address,
            HomePhone = homePhone,
            MobilePhone = mobilePhone,
            WorkPhone = workPhone,
            Email1 = email1,
            Email2 = email2,
            Email3 = email3
        };
    }

    public int GetNumberOfResults()
    {
        manager.Navigation.GoToHomePage();
        String text = driver.FindElement(By.TagName("label")).Text;
        Match m = new Regex(@"\d+").Match(text);
        return Int32.Parse(m.Value);
    }
}