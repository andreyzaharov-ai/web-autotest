
using NUnit.Framework;



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
            
            app.Contacts.Remove();

        }






    }
}