using System;

using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;

using OpenQA.Selenium.Chrome;


namespace web_autotest
{
    /// <summary>
    /// Базовый класс для тестов
    /// </summary>
    public class TestBase
    {
        
        public static bool PERFORM_LONG_UI_CHECKS = true;
        protected AppManager app;
        public static Random rnd = new Random();

        /// <summary>
        /// Метод инициализации тестов
        /// </summary>
        [SetUp]
        public void SetupAppManager()
        {

            app = AppManager.GetInstanse();


        }
        /// <summary>
        /// Метод, генерирующий случайные символы в диапазоне латинского алфавита
        /// </summary>
        /// <param name="max">Кол-во сгенерированных символов</param> 
        /// <returns>Возвращает строку</returns>
        public static string GenerateRandomString(int max)
        {
            
            
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < max; i++)
            {
                builder.Append(Convert.ToChar(65 + Convert.ToInt32(rnd.NextDouble() * 26)));
            }
            return builder.ToString();
        }

    }
}
