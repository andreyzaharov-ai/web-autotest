using NUnit.Framework;
using System.Collections.Generic;


namespace web_autotest
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        /// <summary>
        /// Тест создания группы
        /// </summary> 
        [Test]
        public void TheGroupCreationTest()
        {
            GroupData group = new GroupData("Group1")
            {
                Header = "1Header",
                Footer = "1Footer"
            };
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(group);
            
            Assert.AreEqual(oldGroups.Count +1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);


        }  
    }
}
