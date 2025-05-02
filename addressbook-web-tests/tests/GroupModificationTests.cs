namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("nn");
            newData.Header = "aa";
            newData.Footer = "bb";

            app.Groups.Modify(1, newData);
        }
    }
}