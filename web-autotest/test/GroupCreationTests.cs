using NUnit.Framework;

namespace web_autotest
{
    [TestFixture]
    public class GroupCreation : TestBase
    {
       
        [Test]
        public void TheGroupCreationTest()
        {
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToGroupsPage();
            app.Groups.InitGroupCreation();
            app.Groups.FillGroupForm(new GroupData("aaa", "fff", "ccc"));
            app.Groups.SubmitGroupCreation();
            app.Navigator.ReturnToGroupsPage();
            

        }  
    }
}
