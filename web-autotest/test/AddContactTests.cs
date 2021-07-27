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

        [Test, TestCaseSource("ContactDataFromJsonFile")]
        public void TheAddContactTest(ContactData contact)
        {
            
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
