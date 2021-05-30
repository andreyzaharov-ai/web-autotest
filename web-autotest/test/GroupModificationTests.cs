using NUnit.Framework;

namespace web_autotest
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        /// <summary>
        /// Тест редактирования группы
        /// </summary>
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("aa", "dd", "ff");
            app.Groups.Modify(newData,1);
                


        }
    }
}