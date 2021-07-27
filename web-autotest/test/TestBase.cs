using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
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


        /// <summary>
        /// Метод загрузки данных контактов из JSON
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(File.ReadAllText(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\")) + @"\contacts.json"));

        }

        /// <summary>
        /// Метод загрузки данных контактов из XML
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ContactData> ContactDataFromXMLFile()
        {
            List<ContactData> contacts = new List<ContactData>();

            return (List<ContactData>)new XmlSerializer(typeof(List<ContactData>)).Deserialize(new StreamReader(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\")) + @"\contacts.xml"));

        }
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
