using NUnit.Framework;
using System.Collections.Generic;

namespace web_autotest
{
    [TestFixture]
    public class AddContactTest : AuthTestBase
    {
        /// <summary>
        /// Тест добавления контакта
        /// </summary>

        [Test]
        public void TheAddContactTest()
        {
            ContactData contact = new ContactData()
            {
                FirstName = GenerateRandomString(10),
                LastName = GenerateRandomString(10),
                Address = GenerateRandomString(10),
                HomePhone = GenerateRandomString(10),
                MobilePhone = GenerateRandomString(10),
                WorkPhone = GenerateRandomString(10),
                Email = GenerateRandomString(10),
                Email2 = GenerateRandomString(10),
                Email3 = GenerateRandomString(10)
            };
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            
            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);


        }

        


       
        
    }
}
