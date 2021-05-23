using OpenQA.Selenium;

namespace web_autotest
{
    public class NavigationHelper : HelperBase
    {
        
        private string baseURL;

        public NavigationHelper(IWebDriver driver, string baseURL) : base(driver)
        {
            
            this.baseURL = baseURL;
        }
        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL + "/addressbook/");
        }

        public void GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }
        public void ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }
        public void GoToAddNewContactPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }
        public void ReturnToContactsPage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
        }
    }
}
