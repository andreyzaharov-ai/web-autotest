using System;

using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;

using OpenQA.Selenium.Chrome;


namespace web_autotest
{
    /// <summary>
    /// Базовый класс для тестов
    /// </summary>
    public class TestBase
    {
        protected IWebDriver driver;
        protected AppManager app;

        /// <summary>
        /// Метод инициализации тестов
        /// </summary>
        [SetUp]
        public void SetupTest()
        {
            
            app = new AppManager();
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
        }
        /// <summary>
        /// Метод завершения тестов
        /// </summary>

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
        }
        
      
       

        
        

    }
}
