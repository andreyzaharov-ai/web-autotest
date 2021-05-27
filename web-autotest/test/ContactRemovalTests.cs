
using NUnit.Framework;



namespace web_autotest
{
    [TestFixture]
    public class ContactRemovalTests : TestBase
    {

        [Test]
        public void ContactRemovalTest()
        {
            app.Navigator.GoToContactEditPage();
            app.Contacts.SubmitContactRemoove();

        }






    }
}