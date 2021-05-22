using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace web_autotest
{
    [TestFixture]
    public class AddContactTest : TestBase
    {
        
        [Test]
        public void TheAddContactTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToAddNewContactPage();
            FillNewContactForm(new ContactData("Andrew", "The second"));
            SubmitNewContactCreation();
            ReturnToContactsPage();
            LogOut();
        }

        


       
        
    }
}
