namespace WebAddressBookTests;

public class AuthTestBase : TestBase
{
    [OneTimeSetUp]
    public void SetupLogin()
    {
        app.Auth.Login(new AccountData("admin", "secret"));
    }
}