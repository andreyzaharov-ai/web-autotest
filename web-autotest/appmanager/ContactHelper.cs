using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Text.RegularExpressions;

namespace web_autotest
{
  
    public class ContactHelper : HelperBase
    {
        protected bool acceptNextAlert;

        // конструктор получает драйвер от базового
        public ContactHelper(AppManager manager) : base(manager)
        {
           
        }

        /// <summary>
        /// Метод Редактирования контакта
        /// </summary>
        /// <param name="newData"></param>
        /// <returns></returns>

        public ContactHelper Modify(ContactData newData)
        {
            manager.Navigator.GoToContactEditPage();
            FillNewContactForm(newData);
            SubmitContactUpdate();
            manager.Navigator.ReturnToContactsPage();
            return this;
        }

        /// <summary>
        /// Метод создания контакта
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToAddNewContactPage();
            FillNewContactForm(contact);
            SubmitNewContactCreation();
            manager.Navigator.ReturnToContactsPage();
            return this;
        }

        /// <summary>
        /// Метод удаления контакта
        /// </summary>
        /// <returns></returns>

        public ContactHelper Remove()
        {
            
            SelectContaact();
            RemoveContact();
            //manager.Navigator.ReturnToContactsPage();
            return this;
        }

       

        private void RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            
        }

        private void SelectContaact()
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[2]/td/input")).Click();
        }

        

        // Метод клика на кнопку подтверждения создания контакта

        public ContactHelper SubmitNewContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            return this;
        }

        // Метод клика на кнопку подтверждения удаления контакта

        public ContactHelper SubmitContactRemoove()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[3]")).Click();
            return this;
        }

        // Метод клика на кнопку подтверждения редактирования контакта

        public ContactHelper SubmitContactUpdate()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
            return this;
        }

        // Метод заполнения данными формы создания контакта
        public ContactHelper FillNewContactForm(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
            return this;
        }
    }
}
