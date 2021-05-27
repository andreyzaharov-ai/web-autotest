﻿using OpenQA.Selenium;

namespace web_autotest
{
   public class LoginHelper : HelperBase
    {

        public LoginHelper(AppManager manager) : base(manager)
         {
            
         }
   
        public void Login(AccountData account)
        {
            driver.FindElement(By.Name("user")).Click();
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(account.Username);
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }
    }
}
