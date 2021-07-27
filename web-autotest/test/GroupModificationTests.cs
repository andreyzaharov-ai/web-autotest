using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace web_autotest
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {
        /// <summary>
        /// Тест редактирования группы
        /// </summary>
        [Test]
        public void GroupModificationTest()
        {

            GroupData newData1 = new GroupData()
            {
                Name = GenerateRandomString(5),
                Header = GenerateRandomString(5),
                Footer = GenerateRandomString(5)
            };

            app.Navigator.GoToGroupsPage();
            if (!app.Groups.IsElementPresent(By.CssSelector("span.group")))
            {
                app.Groups.Create(newData1);
            }

            GroupData newData = new GroupData() {
                Name = GenerateRandomString(5),
                Header = GenerateRandomString(5),
                Footer = GenerateRandomString(5)
            };
            
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeModified = oldGroups[0];
            app.Groups.Modify(toBeModified, newData);
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());
            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            foreach (GroupData group in newGroups)
            {
                if (group.Id == toBeModified.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }



        }
    }
}