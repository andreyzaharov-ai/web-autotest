using OpenQA.Selenium;

namespace web_autotest
{
    public class ContactHelper : HelperBase
    {
        // конструктор получает драйвер от базового
        public ContactHelper(AppManager manager) : base(manager)
        {
           
        }

        // Метод клика на кнопку подтверждения создания контакта

        public void SubmitNewContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
        }

        // Метод клика на кнопку подтверждения удаления контакта

        public void SubmitContactRemoove()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[3]")).Click();
        }

        // Метод клика на кнопку подтверждения редактирования контакта

        public void SubmitContactUpdate()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
        }

        // Метод заполнения данными формы создания контакта
        public void FillNewContactForm(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
        }
    }
}
