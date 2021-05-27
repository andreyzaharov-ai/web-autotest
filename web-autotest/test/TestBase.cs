using System;

using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;

using OpenQA.Selenium.Chrome;


namespace web_autotest
{
    public class TestBase
    {
        protected IWebDriver driver;
        protected AppManager app;


        [SetUp]
        public void SetupTest()
        {
            
            app = new AppManager();
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
        }
        
      
       

        
        

    }
}
