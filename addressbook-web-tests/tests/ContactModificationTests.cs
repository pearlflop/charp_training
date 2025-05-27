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
            var i = 0;

            app.Navigation.GoToHomePage();
            if (app.Contact.IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + (i + 1) + "]")) == false)

            {
                app.Contact.Create(contact);
            }

            List<ContactData> oldContacts = app.Contact.GetContactList();

            ContactData oldData = oldContacts[0];

            app.Contact.Modify(i, newData);

            ClassicAssert.AreEqual(oldContacts.Count, app.Contact.GetContactCount());

            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts[0].FirstName = newData.FirstName;
            oldContacts[0].LastName = newData.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            ClassicAssert.AreEqual(oldContacts, newContacts);
            foreach (ContactData contacts in newContacts)
            {
                if (contacts.Id == oldData.Id)
                {
                    ClassicAssert.AreEqual(newData.FirstName, contacts.FirstName);
                    ClassicAssert.AreEqual(newData.LastName, contacts.LastName);
                }
            }
        }
    }
}