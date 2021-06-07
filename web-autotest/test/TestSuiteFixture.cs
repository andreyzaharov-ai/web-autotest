using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace web_autotest

{
    [SetUpFixture]
    public class TestSuiteFixture
    {
        public static AppManager app;
        

        [OneTimeSetUp]
        public void InitApplicationManager()
        {
            app = AppManager.GetInstanse();
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
        }
       
    }
}
