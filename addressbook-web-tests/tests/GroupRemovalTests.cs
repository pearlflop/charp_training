namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            GroupData Data = new GroupData("tt");
            Data.Header = null;
            Data.Footer = null;
            app.Groups.Remove(1, Data);
        }
    }
}