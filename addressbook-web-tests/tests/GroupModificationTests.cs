using NUnit.Framework.Legacy;
using OpenQA.Selenium;

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
            var i = 0;

            app.Navigation.GoToGroupsPage();
            if (app.Groups.IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + (i + 1) + "]")) == false)
            {
                app.Groups.Create(Data);
            }

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData oldData = oldGroups[0];

            app.Groups.Modify(i, newData);

            ClassicAssert.AreEqual(oldGroups.Count, app.Groups.getGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            ClassicAssert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    ClassicAssert.AreEqual(newData.Name, group.Name);
                }
            }
        }
    }
}