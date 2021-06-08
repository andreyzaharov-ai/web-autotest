using NUnit.Framework;
using System.Collections.Generic;


namespace web_autotest
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        /// <summary>
        /// Тест создания группы
        /// </summary> 
        [Test]
        public void TheGroupCreationTest()
        {
            GroupData group = new GroupData("Group1");
            group.Header = "1Header";
            group.Footer = "1Footer";
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(group);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);


        }  
    }
}
