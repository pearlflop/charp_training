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
            var i = 1;

            app.Navigation.GoToGroupsPage();
            if (app.Groups.IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + i + "]")) == false)
            {
                app.Groups.Create(Data);
            }

            app.Groups.Modify(i, newData);
        }
    }
}