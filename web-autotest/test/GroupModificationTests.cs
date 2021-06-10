using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace web_autotest
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        /// <summary>
        /// Тест редактирования группы
        /// </summary>
        [Test]
        public void GroupModificationTest()
        {

            GroupData newData1 = new GroupData("Group1")
            {
                Header = "1Header",
                Footer = "1Footer"
            };

            app.Navigator.GoToGroupsPage();
            if (!app.Groups.IsElementPresent(By.CssSelector("span.group")))
            {
                app.Groups.Create(newData1);
            }

            GroupData newData = new GroupData("Group2");
            newData1.Header = "2Header";
            newData1.Footer = "2Footer";
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Modify(newData, 0);
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);




        }
    }
}