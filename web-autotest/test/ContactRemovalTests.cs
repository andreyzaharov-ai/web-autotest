using OpenQA.Selenium;
using NUnit.Framework;
using System.Collections.Generic;



namespace web_autotest
{
    [TestFixture]
    public class ContactRemovalTests : TestBase
    {
        /// <summary>
        /// Тест удаления контакта
        /// </summary>

        [Test]
        public void ContactRemovalTest()
        {
            ContactData newData = new ContactData("Zarin", "Zarinovich");

            By locator = By.XPath("//td/input");
            if (!app.Groups.isElementPresent(locator))
            {
                app.Contacts.Create(newData);
            }

            

            app.Contacts.Remove();

            

        }






    }
}