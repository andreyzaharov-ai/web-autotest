﻿using System;

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
        
        protected AppManager app;

        /// <summary>
        /// Метод инициализации тестов
        /// </summary>
        [SetUp]
        public void SetupAppManager()
        {

            app = AppManager.GetInstanse();


        }
        

     








    }
}
