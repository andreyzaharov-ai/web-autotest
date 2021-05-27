using NUnit.Framework;

namespace web_autotest
{
    [TestFixture]
    public class ContactEditTests : TestBase
    {
        [Test]

        // Тест редактированя контакта
        public void ContactEditTest()
        {
            app.Navigator.GoToContactEditPage();
            app.Contacts.FillNewContactForm(new ContactData("Zarin", "Zarinovich"));
            app.Contacts.SubmitContactUpdate();
        }
    }
}