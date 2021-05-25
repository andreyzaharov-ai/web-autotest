using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace web_autotest
{
    public class AppManager
    {
        // Объявляем переменные и помощники

        protected IWebDriver driver;
        protected string baseURL;
        protected LoginHelper loginHelper;
        protected NavigationHelper navigator;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;

        // Инициируем переменные и помощники
        public AppManager()
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost";
            loginHelper = new LoginHelper(driver);
            navigator = new NavigationHelper(driver, baseURL);
            groupHelper = new GroupHelper(driver);
            contactHelper = new ContactHelper(driver);
        }

        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }
        public NavigationHelper Navigator
        {
            get
            {
                return navigator;
            }
        }
        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }
        public ContactHelper Contacts
        {
            get
            {
                return contactHelper;
            }
        }
        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            
        }
    }
}
