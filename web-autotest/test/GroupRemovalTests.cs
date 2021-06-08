using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace web_autotest
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        /// <summary>
        /// Тест Удаления группы
        /// </summary>
        [Test]
        public void GroupRemovalTest()
        {
            GroupData newData1 = new GroupData("Group1");
            newData1.Header = "1Header";
            newData1.Footer = "1Footer";
            By locator = By.CssSelector("span.group");
            if (!app.Groups.isElementPresent(locator))
            {
                app.Groups.Create(newData1);
            }
                List<GroupData> oldGroups = app.Groups.GetGroupList();

                app.Groups.Remove(0);

                List<GroupData> newGroups = app.Groups.GetGroupList();

                oldGroups.RemoveAt(0);
                Assert.AreEqual(oldGroups, newGroups);
            
        }

    }
}
