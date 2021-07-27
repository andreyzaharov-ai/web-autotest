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
        public static Random rnd = new Random();
        public HelperBase(AppManager manager)
        {
            this.manager = manager;
            driver = manager.Driver;
        }

        public Boolean IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
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
        /// <summary>
        /// Генерация дня
        /// </summary>
        /// <returns></returns>
        public static string GenerateRandomDay()
        {
            int day = rnd.Next(1, 32);
            return day.ToString();
        }

        /// <summary>
        /// Генерация месяца
        /// </summary>
        /// <returns></returns>
        public static string GenerateRandomMonth()
        {
            string[] RM = { "January", "February", "March", "April", "May", "June", "July",
                            "August", "September", "October", "November", "December" };
            int MM = rnd.Next(RM.Length);
            return RM[MM];
        }

        /// <summary>
        /// Генерация года
        /// </summary>
        /// <returns></returns>
        public static string GenerateRandomYear()
        {
            int year = rnd.Next(1900, 2022);
            return year.ToString();
        }
    }
}