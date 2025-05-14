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

    public GroupHelper Modify(int i, GroupData newData, GroupData Data)
    {
        manager.Navigation.GoToGroupsPage();
        if (IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + i + "]")) == false)
        {
            Create(Data);
        }

        SelectGroup(i);
        initGroupModification();
        FillGroupsForm(newData);
        SubmitGroupModification();
        ReturnToGroupsPage();
        return this;
    }

    public GroupHelper Remove(int i, GroupData Data)
    {
        manager.Navigation.GoToGroupsPage();
        if (IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + i + "]")) == false)
        {
            Create(Data);
        }

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
        return this;
    }

    public GroupHelper ReturnToGroupsPage()
    {
        driver.FindElement(By.LinkText("group page")).Click();
        return this;
    }

    public GroupHelper SelectGroup(int index)
    {
        driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
        return this;
    }

    public GroupHelper RemoveGroup()
    {
        driver.FindElement(By.Name("delete")).Click();
        return this;
    }

    private GroupHelper SubmitGroupModification()
    {
        driver.FindElement(By.Name("update")).Click();
        return this;
    }

    private GroupHelper initGroupModification()
    {
        driver.FindElement(By.Name("edit")).Click();
        return this;
    }
}