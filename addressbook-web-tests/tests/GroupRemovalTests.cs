using NUnit.Framework.Legacy;
using OpenQA.Selenium;

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
            var i = 1;

            app.Navigation.GoToGroupsPage();
            if (app.Navigation.IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + i + "]")) == false)
            {
                app.Groups.Create(Data);
            }

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Remove(0);

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.RemoveAt(0);
            ClassicAssert.AreEqual(oldGroups, newGroups);
        }
    }
}