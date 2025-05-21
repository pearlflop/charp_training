using NUnit.Framework.Legacy;
using OpenQA.Selenium;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("qq", "bb");
            ContactData contact = new ContactData("aa", "cc");
            var i = 27;

            app.Navigation.GoToHomePage();
            if (app.Contact.IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + i + "]")) == false)

            {
                app.Contact.Create(contact);
            }

            List<ContactData> oldContacts = app.Contact.GetContactList();
            app.Contact.Modify(i, newData);
            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts[0].FirstName = newData.FirstName;
            oldContacts[0].LastName = newData.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            ClassicAssert.AreEqual(oldContacts, newContacts);
        }
    }
}