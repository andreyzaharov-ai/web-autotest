using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace web_autotest
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
    {
        /// <summary>
        /// Тест Удаления группы
        /// </summary>
        [Test]
        public void GroupRemovalTest()
        {
            GroupData newData1 = new GroupData()
            {
                Name = GenerateRandomString(5),
                Header = GenerateRandomString(5),
                Footer = GenerateRandomString(5)
            };
            app.Navigator.GoToGroupsPage();
            if (GroupData.GetAll().Count == 0)
            {
                app.Groups.Create(newData1);
            }
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData tobeRemoved = oldGroups[0];
            app.Groups.Remove(tobeRemoved);
            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());
            List<GroupData> newGroups = GroupData.GetAll();
            
            oldGroups.RemoveAt(0);
                Assert.AreEqual(oldGroups, newGroups);
            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, tobeRemoved.Id);
            }
            
        }

    }
}
