using OpenQA.Selenium;

namespace web_autotest
{
    public class NavigationHelper : HelperBase
    {
        // объявляем базвый путь
        private string baseURL;

        // Конструируем помошника навигации
        public NavigationHelper(AppManager manager, string baseURL) : base(manager)
        {
            
            this.baseURL = baseURL;
        }

        // метод перехода на главную
        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL + "/addressbook/");
        }

        // метод перехода на страницу групп
        public void GoToGroupsPage()
        {
            if (driver.Url == baseURL + "/addressbook/group.php" && IsElementPresent(By.Name("new")))
            { 
                return; 
            }
            driver.FindElement(By.LinkText("groups")).Click();
        }

        // метод перехода на страницу контактов
        public void GoToContactEditPage()
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
        }

        

        // метод перехода на страницу создания контакта
        public void GoToAddNewContactPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        // метод возврата на страницу контактов/главную страницу
        public void ReturnToContactsPage()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }
    }
}
