namespace WebAddressBookTests;

public class TestBase
{
    protected ApplicationManager app;

    [SetUp]
    public void SetupTest()
    {
        app = new ApplicationManager();
        app.Navigation.OpenHomePage();
        app.Auth.Login(new AccountData("admin", "secret"));
    }

    [TearDown]
    public void TeardownTest()
    {
        app.Stop();
    }
}