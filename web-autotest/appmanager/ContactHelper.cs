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

        /// <summary>
        /// Метод получения данных контакта с главной страницы
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.OpenHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;
            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones

            };
        }

        private List<ContactData> contactCache = null;

        /// <summary>
        /// Метод получеия даных о контакте из формы редактированя
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.OpenHomePage();
            InitContactModification(0);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            return new ContactData(firstName, lastName)
            {
                Address=address, HomePhone=homePhone, MobilePhone=mobilePhone, WorkPhone=workPhone
            };
        }

        internal List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.OpenHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
                foreach (IWebElement element in elements)
                {
                    ContactData contact = new ContactData()
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
            manager.Navigator.OpenHomePage();
            
            InitContactModification(0);
            FillNewContactForm(newData);
            manager.Navigator.ReturnToContactsPage();
            return this;
        }

        /// <summary>
        /// Метод инициализаци редактирования контакта
        /// </summary>
        /// <param name="index"></param>

        private void InitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
            
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
            contactCache = null;
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
