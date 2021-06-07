using OpenQA.Selenium;
using System;
using NUnit.Framework;

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

        public Boolean isElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException e)
            {
                return false;
            }
        }

        public void Type(By locator, string text)
        {
            if (text != null)
            {
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(text);
            }

        }
    }
}