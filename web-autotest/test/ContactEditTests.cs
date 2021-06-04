using NUnit.Framework;
using OpenQA.Selenium;

namespace web_autotest
{
    [TestFixture]
    public class ContactEditTests : TestBase
    {
        /// <summary>
        /// Тест редактирования контакта
        /// </summary>
        [Test]

        

        public void ContactEditTest()
        {
            ContactData newData = new ContactData("Zarin", "Zarinovich");

            
            By locator = By.XPath("//td/input");
            if (!app.Groups.isElementPresent(locator))
            {
                app.Contacts.Create(newData);
            }
            
                ContactData newData2 = new ContactData("milana", "Ivanovna");

                app.Contacts.Modify(newData2);
                
        }
    }
}