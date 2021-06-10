using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private List<ContactData> contactCache = null;
        

        internal List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.OpenHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
                foreach (IWebElement element in elements)
                {
                    ContactData contact = new ContactData
                    {
                        FirstName = driver.FindElement(By.CssSelector("td:nth-of-type(3n)")).Text,
                        LastName = driver.FindElement(By.CssSelector("td:nth-of-type(2n)")).Text
                    };
                    contactCache.Add(contact);

                }
            }

            return new List<ContactData>(contactCache);
        }

        internal double GetContactCount()
        {
            return driver.FindElements(By.Name("entry")).Count; ;
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
            manager.Navigator.ReturnToContactsPage();
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
            contactCache = null;
            return this;
        }

        // Метод клика на кнопку подтверждения удаления контакта

        public ContactHelper SubmitContactRemoove()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[3]")).Click();
            contactCache = null;
            return this;
        }

        // Метод клика на кнопку подтверждения редактирования контакта

        public ContactHelper SubmitContactUpdate()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
            contactCache = null;
            return this;
        }

        // Метод заполнения данными формы создания контакта
        public ContactHelper FillNewContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("lastname"), contact.LastName);
            return this;
        }
    }
}
