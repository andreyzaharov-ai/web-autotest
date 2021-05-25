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
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToContactEditPage();
            app.Contacts.SubmitContactUpdate();
        }
    }
}