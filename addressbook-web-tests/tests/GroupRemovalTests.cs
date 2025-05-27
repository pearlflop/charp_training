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

            ClassicAssert.AreEqual(oldGroups.Count - 1, app.Groups.getGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();

            GroupData toBeRemoved = oldGroups[0];
            oldGroups.RemoveAt(0);
            ClassicAssert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                ClassicAssert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}