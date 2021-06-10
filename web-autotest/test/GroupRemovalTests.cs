﻿using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace web_autotest
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        /// <summary>
        /// Тест Удаления группы
        /// </summary>
        [Test]
        public void GroupRemovalTest()
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
                List<GroupData> oldGroups = app.Groups.GetGroupList();

                app.Groups.Remove(0);
            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());
            List<GroupData> newGroups = app.Groups.GetGroupList();

                oldGroups.RemoveAt(0);
                Assert.AreEqual(oldGroups, newGroups);
            
        }

    }
}
