using OpenQA.Selenium;

namespace web_autotest
{
    public class NavigationHelper : HelperBase
    {
        // объявляем базвый путь
        private string baseURL;

        // Конструируем помошника навигации
        public NavigationHelper(IWebDriver driver, string baseURL) : base(driver)
        {
            
            this.baseURL = baseURL;
        }

        // метод перехода на домашнюю страницу
        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL + "/addressbook/");
        }

        // метод перехода на страницу групп
        public void GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

        // метод перехода на страницу контактов
        public void GoToContactEditPage()
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
        }

        // метод возврата на страницу групп
        public void ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }

        // метод перехода на страницу создания контакта
        public void GoToAddNewContactPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        // метод возврата на страницу контактов/главную страницу
        public void ReturnToContactsPage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
        }
    }
}
