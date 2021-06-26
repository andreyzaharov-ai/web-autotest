using OpenQA.Selenium;
using System;

namespace web_autotest
{
   public class LoginHelper : HelperBase
    {

        public LoginHelper(AppManager manager) : base(manager)
         {
            
         }
        /// <summary>
        /// Метод авторизации
        /// </summary>
        /// <param name="account"></param>
   
        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }
                Logout();
            }
            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }
        /// <summary>
        /// вспомогательный метод проверки наличия авторизации
        /// </summary>
        /// <returns></returns>

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
        }

        /// <summary>
        /// вспомогательный метод проверки наличия конкретной авторизации
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn() && GetLoggedUserName() == account.Username;
                
        }

        /// <summary>
        /// Метод получения имени пользователя
        /// </summary>
        /// <returns></returns>

        public string GetLoggedUserName()
        {
            string text = driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text;
            return text.Substring(1, text.Length - 2);
        }

        /// <summary>
        /// Logout 
        /// </summary>

        public void Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }
    }
}
