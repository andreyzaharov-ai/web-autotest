using NUnit.Framework;
using OpenQA.Selenium;

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
            GroupData newData1 = new GroupData("aa", "dd", "ff");
            By locator = By.XPath("//div[@id='content']/form/span/input");
            if (!app.Groups.isElementPresent(locator))
            {
                app.Groups.Create(newData1);
            }
           
                GroupData newData = new GroupData("ff", "dd", "ff");
                app.Groups.Modify(newData, 1);
                       
                


        }
    }
}