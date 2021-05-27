using NUnit.Framework;

namespace web_autotest
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {

        [Test]
        public void GroupModificationTest()
        {
            
            app.Navigator.GoToGroupsPage();
            app.Groups.SelectGroup(1)
                .InitGroupModification()
                .FillGroupForm(new GroupData("kkkk", "llll", "qqqq"))
                .SubmitGroupModification()
                .ReturnToGroupsPage();


        }
    }
}