using OpenQA.Selenium;
namespace web_autotest
{
    /// <summary>
    /// Базовый помошник
    /// </summary>
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