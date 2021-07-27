using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace web_autotest
{
    [TestFixture]
    public class ContactEditTests : AuthTestBase
    {
        /// <summary>
        /// Тест редактирования контакта
        /// </summary>
        [Test, TestCaseSource("ContactDataFromJsonFile")]
        public void ContactEditTest(ContactData contact)
        {
           
            List<ContactData> oldContacts1 = app.Contacts.GetContactList();
            if (oldContacts1.Count == 0)
            {
                app.Contacts.Create(contact);
            }
            
            ContactData newData2 = new ContactData()
            {
             FirstName = "Edited_contact_First_Name",
             LastName = "Edited_contact_Middle_Name",
             MiddleName = "Edited_contact_Last_Name",
             Nickname = "Edited_contact_Nick_Name",
             Title = "Edited_contact_Nick_Title",
             Company = "Edited_contact_Company",
             Address = "Edited_contact_Address",
             HomePhone = "Edited_contact_HomePhone",
             MobilePhone = "Edited_contact_MobilePhone",
             WorkPhone = "Edited_contact_WorkPhone",
             Fax = "Edited_contact_Fax",
             Email1 = "Edited_contact_Email1",
             Email2 = "Edited_contact_Email2",
             Email3 = "Edited_contact_Email3",
             Homepage = "Edited_contact_Homepage",
             YearhOfBirth = "1945",
             YearOfAnniversary = "1945",
             SecondaryAddress = "Edited_contact_SecondaryAddress",
             SecondaryHomePhone = "Edited_contact_SecondaryHomePhone",
             Notes = "Edited_contact_Notes"
            };
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Modify(newData2, 1);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].FirstName = newData2.FirstName;
            oldContacts[0].LastName = newData2.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}