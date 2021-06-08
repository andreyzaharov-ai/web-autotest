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
            
            GroupData newData1 = new GroupData("Group1");
            newData1.Header = "1Header";
            newData1.Footer = "1Footer";
            By locator = By.XPath("//div[@id='content']/form/span/input");
            if (!app.Groups.isElementPresent(locator))
            {
                app.Groups.Create(newData1);
            }

            GroupData newData = new GroupData("Group2");
            newData1.Header = "2Header";
            newData1.Footer = "2Footer";
            app.Groups.Modify(newData, 0);
                       
                


        }
    }
}