using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace web_autotest
{
    [TestFixture]
    public class ContactEditTests : AuthTestBase
    {
        /// <summary>
        /// Тест редактирования контакта
        /// </summary>
        [Test]

        

        public void ContactEditTest()
        {
            ContactData newData = new ContactData("Zarin", "Zarinovich");

            
            By locator = By.XPath("//td/input");
            if (!app.Groups.IsElementPresent(locator))
            {
                app.Contacts.Create(newData);
            }
            
                ContactData newData2 = new ContactData("milana", "Ivanovna");
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Modify(newData2);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].FirstName = newData2.FirstName;
            oldContacts[0].LastName = newData2.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}