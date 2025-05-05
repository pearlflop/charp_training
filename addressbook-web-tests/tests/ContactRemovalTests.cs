namespace WebAddressBookTests;

[TestFixture]
public class ContactRemovalTests : AuthTestBase
{
    [Test]
    public void ContactRemovalTest()
    {
        ContactData contact = new ContactData("aa", "cc");
        app.Contact.Remove(1, contact);
    }
}