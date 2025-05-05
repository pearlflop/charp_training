using NUnit.Framework.Legacy;

namespace WebAddressBookTests;

[TestFixture]
public class LoginTests : TestBase
{
    [Test]
    public void LoginWithValidCredentials()
    {
        //prepare
        app.Auth.Logout();

        //action
        AccountData account = new AccountData("admin", "secret");
        app.Auth.Login(account);

        //verification
        ClassicAssert.IsTrue(app.Auth.isLoggedIn(account));
    }
    
    [Test]
    public void LoginWithInValidCredentials()
    {
        //prepare
        app.Auth.Logout();

        //action
        AccountData account = new AccountData("admin", "123456");
        app.Auth.Login(account);

        //verification
        ClassicAssert.IsFalse(app.Auth.isLoggedIn());
    }
}