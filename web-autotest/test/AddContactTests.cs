using NUnit.Framework;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace web_autotest
{
    [TestFixture]
    public class AddContactTest : AuthTestBase
    {
        /// <summary>
        /// Метод загрузки данных контактов из JSON
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(File.ReadAllText(@"C:\Users\Andrey\source\repos\web-autotest\web-autotest\contacts.json"));

        }
        /// <summary>
        /// Метод загрузки данных контактов из XML
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ContactData> ContactDataFromXMLFile()
        {
            List<ContactData> contacts = new List<ContactData>();

            return (List<ContactData>)new XmlSerializer(typeof(List<ContactData>)).Deserialize(new StreamReader(@"C:\Users\Andrey\source\repos\web-autotest\web-autotest\contacts.xml"));

        }
        /// <summary>
        /// Тест добавления контакта
        /// </summary>

        [Test, TestCaseSource("ContactDataFromXMLFile")]
        public void TheAddContactTest(ContactData contact)
        {
            /* ContactData contact = new ContactData()
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
            */
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
