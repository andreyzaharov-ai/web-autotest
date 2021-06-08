
using NUnit.Framework;

namespace web_autotest

{
    [SetUpFixture]
    public class TestSuiteFixture
    {
        [OneTimeSetUp]
        public void InitApplicationManager()
        {
            AppManager app = AppManager.GetInstanse();
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
        }
       
    }
}
