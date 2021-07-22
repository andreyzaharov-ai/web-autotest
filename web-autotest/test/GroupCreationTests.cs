using NUnit.Framework;
using System.IO;
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
            GroupData group = new GroupData()
            {
                Name = GenerateRandomString(5),
                Header = GenerateRandomString(5),
                Footer = GenerateRandomString(5)
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
