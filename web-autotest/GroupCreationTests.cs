using NUnit.Framework;

namespace web_autotest
{
    [TestFixture]
    public class GroupCreation : TestBase
    {
       
        [Test]
        public void TheGroupCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(new GroupData("aaa", "fff", "ccc"));
            SubmitGroupCreation();
            ReturnToGroupsPage();
            LogOut();

        }  
    }
}
