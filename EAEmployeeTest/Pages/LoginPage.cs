using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAAutoFramework.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using EAAutoFramework.Extensions;

namespace EAEmployeeTest.Pages
{
    class LoginPage : BasePage
    {
        //Initialize page login
        public LoginPage()
        {
        }

        public IWebElement txtUserName => _driver.FindElement(By.Name("UserName"));
        public IWebElement txtPassword => _driver.FindElement(By.Id("Password"));
        public IWebElement btnLogin => _driver.FindElement(By.CssSelector("input.btn"));

        public void Login(string username, string password)
        {
            txtUserName.SendKeys(username);
            txtPassword.SendKeys(password);
        }

        public HomePage ClickLoginButton()
        {
            btnLogin.Submit();
            return GetInstance<HomePage>();
        }

        internal void CheckIfLoginExists()
        {
            txtUserName.AssertElementPresent();
        }
    }
}
