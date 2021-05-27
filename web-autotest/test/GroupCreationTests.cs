using NUnit.Framework;

namespace web_autotest
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
       
        [Test]
        public void TheGroupCreationTest()
        {
            GroupData group = new GroupData("aa", "dd", "ff");
            app.Groups.Create(group);



        }  
    }
}
