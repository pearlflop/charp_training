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
            app.Contact.Modify(1, newData, contact);
        }
    }
}