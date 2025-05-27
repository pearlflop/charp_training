using OpenQA.Selenium;

namespace WebAddressBookTests;

public class GroupHelper : HelperBase
{
    public GroupHelper(ApplicationManager manager) : base(manager)
    {
    }

    public GroupHelper Create(GroupData group)
    {
        manager.Navigation.GoToGroupsPage();

        InitGroupCreation();
        FillGroupsForm(group);
        SubmitGroupCreation();
        ReturnToGroupsPage();
        return this;
    }

    public GroupHelper Modify(int i, GroupData newData)
    {
        SelectGroup(i);
        initGroupModification();
        FillGroupsForm(newData);
        SubmitGroupModification();
        ReturnToGroupsPage();
        return this;
    }

    public GroupHelper Remove(int i)
    {
        SelectGroup(i);
        RemoveGroup();
        ReturnToGroupsPage();
        return this;
    }

    public GroupHelper InitGroupCreation()
    {
        driver.FindElement(By.Name("new")).Click();
        return this;
    }

    public GroupHelper FillGroupsForm(GroupData group)
    {
        Type(By.Name("group_name"), group.Name);
        Type(By.Name("group_header"), group.Header);
        Type(By.Name("group_footer"), group.Footer);
        return this;
    }

    public GroupHelper SubmitGroupCreation()
    {
        driver.FindElement(By.Name("submit")).Click();
        groupCache = null;
        return this;
    }

    public GroupHelper ReturnToGroupsPage()
    {
        driver.FindElement(By.LinkText("group page")).Click();
        return this;
    }

    public GroupHelper SelectGroup(int index)
    {
        driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
        return this;
    }

    public GroupHelper RemoveGroup()
    {
        driver.FindElement(By.Name("delete")).Click();
        groupCache = null;
        return this;
    }

    private GroupHelper SubmitGroupModification()
    {
        driver.FindElement(By.Name("update")).Click();
        groupCache = null;
        return this;
    }

    private GroupHelper initGroupModification()
    {
        driver.FindElement(By.Name("edit")).Click();
        return this;
    }

    private List<GroupData> groupCache = null;

    public List<GroupData> GetGroupList()
    {
        if (groupCache == null)
        {
            groupCache = new List<GroupData>();
            manager.Navigation.GoToGroupsPage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
            foreach (IWebElement element in elements)
            {
                groupCache.Add(new GroupData(null)
                {
                    Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                });
            }

            string allGroupsNames = driver.FindElement(By.CssSelector("div#content form")).Text;
            string[] parts = allGroupsNames.Split('\n');
            int shift = groupCache.Count - parts.Length;
            for (int i = 0; i < groupCache.Count; i++)
            {
                if (i < shift)
                {
                    groupCache[i].Name = "";
                }
                else
                {
                    groupCache[i].Name = parts[i - shift].Trim();
                }
            }
        }

        return new List<GroupData>(groupCache);
    }

    public int getGroupCount()
    {
        return driver.FindElements(By.CssSelector("span.group")).Count;
    }
}