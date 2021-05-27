using NUnit.Framework;
using OpenQA.Selenium;

namespace web_autotest
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            app.Groups.Remove(1);

        }

    }
}
