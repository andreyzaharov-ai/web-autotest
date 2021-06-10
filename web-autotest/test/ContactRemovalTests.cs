using OpenQA.Selenium;
using NUnit.Framework;
using System.Collections.Generic;



namespace web_autotest
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        /// <summary>
        /// Тест удаления контакта
        /// </summary>

        [Test]
        public void ContactRemovalTest()
        {
            ContactData newData = new ContactData("Zarin", "Zarinovich");

            By locator = By.XPath("//td/input");
            if (!app.Groups.IsElementPresent(locator))
            {
                app.Contacts.Create(newData);
            }

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Remove();
            

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());
            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts.RemoveAt(0);


            Assert.AreEqual(oldContacts, newContacts);


        }






    }
}