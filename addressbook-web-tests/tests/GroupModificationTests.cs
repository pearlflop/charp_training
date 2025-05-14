namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("nn");
            GroupData Data = new GroupData("tt");
            newData.Header = null;
            newData.Footer = null;
            Data.Header = null;
            Data.Footer = null;

            app.Groups.Modify(1, newData, Data);
        }
    }
}