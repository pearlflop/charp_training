namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";
            
            app.Groups.Create(group);
        }
        
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("n");
            group.Header = "n";
            group.Footer = "n";
            
            app.Groups.Create(group);
        }
    }
}