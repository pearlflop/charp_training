namespace WebAddressBookTests;

[TestFixture]
public class ContactRemovalTests : TestBase
{
    [Test]
    public void ContactRemovalTest()
    {
        app.Contact.Remove(1);
    }
}