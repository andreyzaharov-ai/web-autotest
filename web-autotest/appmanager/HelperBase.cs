using OpenQA.Selenium;
namespace web_autotest
{
    public class HelperBase
    {
        protected AppManager manager;
        protected IWebDriver driver;
        public HelperBase(AppManager manager)
        {
            this.manager = manager;
            driver = manager.Driver;
        }
    }
}