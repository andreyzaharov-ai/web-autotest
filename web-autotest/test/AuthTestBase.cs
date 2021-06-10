using NUnit.Framework;

namespace web_autotest
{
    public class AuthTestBase : TestBase
    {
        [SetUp]
        public void SetupLogin()
        {

            app.Auth.Login(new AccountData("admin", "secret"));

        }
    }
}
