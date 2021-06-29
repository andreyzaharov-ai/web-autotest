
using NUnit.Framework;



namespace web_autotest
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        /// <summary>
        /// Тест сверки информации о контакте с главной страницы с формой редактирования контакта
        /// </summary>
        [Test]

        public void ContactInformationTest()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        }

        /// <summary>
        /// Тест сверки информации о контакте со страницы детальной информации с формой редактирования контакта
        /// </summary>

        [Test]
        public void DetailsInformationTest()
        {
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);
            ContactData fromDetails = app.Contacts.GetContactInformationFromDetails(0);
            Assert.AreEqual(fromDetails.ContactDetails, fromForm.ContactDetails);
        }
    }
}
