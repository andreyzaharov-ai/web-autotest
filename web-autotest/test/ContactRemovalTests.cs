using NUnit.Framework;
using System.Collections.Generic;

namespace web_autotest
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase

    {
       
        /// <summary>
        /// Тест удаления контакта
        /// </summary>

        [Test, TestCaseSource("ContactDataFromJsonFile")]
        public void ContactRemovalTest(ContactData contact)
        {

            if (app.Contacts.GetContactList().Count == 0)
            {
                app.Contacts.Create(contact);
            }

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Remove();
            

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());
            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts.RemoveAt(0);


            Assert.AreEqual(oldContacts, newContacts);


        }






    }
}