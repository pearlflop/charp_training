using NUnit.Framework.Legacy;
using OpenQA.Selenium;

namespace WebAddressBookTests;

[TestFixture]
public class ContactRemovalTests : AuthTestBase
{
    [Test]
    public void ContactRemovalTest()
    {
        ContactData contact = new ContactData("aa", "cc");
        var i = 1;

        app.Navigation.GoToHomePage();
        if (app.Contact.IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + i + "]")) == false)
        {
            app.Contact.Create(contact);
        }

        List<ContactData> oldContacts = app.Contact.GetContactList();
        app.Contact.Remove(i);


        List<ContactData> newContacts = app.Contact.GetContactList();
        oldContacts.RemoveAt(0);
        oldContacts.Sort();
        newContacts.Sort();
        ClassicAssert.AreEqual(oldContacts, newContacts);
    }
}