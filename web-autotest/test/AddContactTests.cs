using NUnit.Framework;

namespace web_autotest
{
    [TestFixture]
    public class AddContactTest : TestBase
    {
        /// <summary>
        /// Тест добавления контакта
        /// </summary>

        [Test]
        public void TheAddContactTest()
        {
            ContactData contact = new ContactData("Andrew", "The second");
            app.Contacts.Create(contact); 
            
        }

        


       
        
    }
}
