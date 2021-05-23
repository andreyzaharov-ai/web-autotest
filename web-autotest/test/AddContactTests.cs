﻿
using NUnit.Framework;



namespace web_autotest
{
    [TestFixture]
    public class AddContactTest : TestBase
    {
        
        [Test]
        public void TheAddContactTest()
        {
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToAddNewContactPage();
            app.Contacts.FillNewContactForm(new ContactData("Andrew", "The second"));
            app.Contacts.SubmitNewContactCreation();
            app.Navigator.ReturnToContactsPage();
            
        }

        


       
        
    }
}
