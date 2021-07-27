using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
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
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;
            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllEmails = allEmails,
                AllPhones = allPhones
                
            };
        }

        /// <summary>
        /// Метод получения данных о контакте со страницы детальной информации о контакте 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>

        public ContactData GetContactInformationFromDetails(int index)
        {
            manager.Navigator.OpenHomePage();
            OpenContactsDetail(index);
            IList<IWebElement> cells = driver.FindElements(By.Id("content"));

            string contactDetails = cells[0].Text;

            return new ContactData()
            {
                ContactDetails = contactDetails
            };
        }
        /// <summary>
        /// Метод открытия страницы детальной информации о контакте
        /// </summary>
        /// <param name="index"></param>
        private void OpenContactsDetail(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[6]
                .FindElement(By.TagName("a")).Click();
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
            InitContactModification(index);
            return new ContactData()
            {
                FirstName = driver.FindElement(By.Name("firstname")).GetAttribute("value"),
                MiddleName = driver.FindElement(By.Name("middlename")).GetAttribute("value"),
                LastName = driver.FindElement(By.Name("lastname")).GetAttribute("value"),
                Nickname = driver.FindElement(By.Name("nickname")).GetAttribute("value"),
                Company = driver.FindElement(By.Name("company")).GetAttribute("value"),
                Title = driver.FindElement(By.Name("title")).GetAttribute("value"),
                Address = driver.FindElement(By.Name("address")).GetAttribute("value"),
                HomePhone = driver.FindElement(By.Name("home")).GetAttribute("value"),
                MobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value"),
                WorkPhone = driver.FindElement(By.Name("work")).GetAttribute("value"),
                Fax = driver.FindElement(By.Name("fax")).GetAttribute("value"),
                Email1 = driver.FindElement(By.Name("email")).GetAttribute("value"),
                Email2 = driver.FindElement(By.Name("email2")).GetAttribute("value"),
                Email3 = driver.FindElement(By.Name("email3")).GetAttribute("value"),
                Homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value"),
                Birthday = driver.FindElement(By.Name("bday")).GetAttribute("value"),
                MonthOfBirth = driver.FindElement(By.Name("bmonth")).GetAttribute("value"),
                YearhOfBirth = driver.FindElement(By.Name("byear")).GetAttribute("value"),
                AnniversaryDay = driver.FindElement(By.Name("aday")).GetAttribute("value"),
                MonthOfAnniversary = driver.FindElement(By.Name("amonth")).GetAttribute("value"),
                YearOfAnniversary = driver.FindElement(By.Name("ayear")).GetAttribute("value"),
                SecondaryAddress = driver.FindElement(By.Name("address2")).GetAttribute("value"),
                SecondaryHomePhone = driver.FindElement(By.Name("phone2")).GetAttribute("value"),
                Notes = driver.FindElement(By.Name("notes")).GetAttribute("value")
            };
        }

        internal List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.OpenHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name='entry']"));
                foreach (IWebElement element in elements)
                {
                    string firstName = element.FindElement(By.CssSelector("td:nth-of-type(3n)")).Text;
                    string lastName = element.FindElement(By.CssSelector("td:nth-of-type(2n)")).Text;                   
                    contactCache.Add(new ContactData(firstName, lastName)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });

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

        public ContactHelper Modify(ContactData newData, int index)
        {
            manager.Navigator.OpenHomePage();
            
            InitContactModification(index);
            FillNewContactForm(newData);
            SubmitContactUpdate();
            manager.Navigator.ReturnToContactsPage();
            return this;
        }

        /// <summary>
        /// Метод инициализаци редактирования контакта
        /// </summary>
        /// <param name="index"></param>

        private void InitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index-1]
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
            Type(By.Name("middlename"), contact.MiddleName);
            Type(By.Name("lastname"), contact.LastName);
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.HomePhone);
            Type(By.Name("mobile"), contact.MobilePhone);
            Type(By.Name("work"), contact.WorkPhone);
            Type(By.Name("fax"), contact.Fax);
            Type(By.Name("email"), contact.Email1);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            Type(By.Name("homepage"), contact.Homepage);

            driver.FindElement(By.Name("bday")).Click();
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(GenerateRandomDay());
            driver.FindElement(By.Name("bmonth")).Click();
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(GenerateRandomMonth());
            Type(By.Name("byear"), contact.YearhOfBirth);
            driver.FindElement(By.Name("aday")).Click();
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(GenerateRandomDay());
            driver.FindElement(By.Name("amonth")).Click();
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(GenerateRandomMonth());
            Type(By.Name("ayear"), contact.YearOfAnniversary);

            Type(By.Name("address2"), contact.SecondaryAddress);
            Type(By.Name("phone2"), contact.SecondaryHomePhone);
            Type(By.Name("notes"), contact.Notes);
            return this;
        }
    }
}
