using NUnit.Framework.Legacy;

namespace WebAddressBookTests;

[TestFixture]
public class ContactInformationTests : AuthTestBase
{
    [Test]
    public void TestGetContactInformation()
    {
        ContactData fromTable = app.Contact.GetContactInformationFromTable(0);
        ContactData fromForm = app.Contact.GetContactInformationFromEditForm(0);
        ContactData fromViewForm = app.Contact.GetContactInformationFromViewForm(0);

        ClassicAssert.AreEqual(fromTable, fromForm);
        ClassicAssert.AreEqual(fromTable.Address, fromForm.Address);
        ClassicAssert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        ClassicAssert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        ClassicAssert.AreEqual(fromViewForm, fromForm);
    }
}