using NUnit.Framework;
using OpenQA.Selenium;

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
            GroupData newData1 = new GroupData("aa", "dd", "ff");
            By locator = By.XPath("//div[@id='content']/form/span/input");
            if (!app.Groups.isElementPresent(locator))
            {
                app.Groups.Create(newData1);
            }
            app.Groups.Remove(1);
        }

    }
}
