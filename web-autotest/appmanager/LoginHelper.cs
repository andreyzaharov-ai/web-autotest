using OpenQA.Selenium;

namespace web_autotest
{
   public class LoginHelper : HelperBase
    {

        public LoginHelper(AppManager manager) : base(manager)
         {
            
         }
   
        public void Login(AccountData account)
        {
            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }
    }
}
