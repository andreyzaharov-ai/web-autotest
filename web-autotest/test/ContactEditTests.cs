using NUnit.Framework;

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

            app.Contacts.Modify(newData);
        }
    }
}