using NUnit.Framework;

namespace web_autotest
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {

        [Test]
        public void GroupModificationTest()
        {
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToGroupsPage();
            app.Groups.SelectGroup(1);
            app.Groups.InitGroupModification();
            app.Groups.FillGroupForm(new GroupData("kkkk", "llll", "qqqq"));
            app.Groups.SubmitGroupModification();
            app.Navigator.ReturnToGroupsPage();


        }
    }
}