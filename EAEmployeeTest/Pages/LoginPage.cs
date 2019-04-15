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
    public class LoginPage : BasePage
    {
        //Initialize page login
        public LoginPage()
        {
        }

        public IWebElement lnkLogin => _driver.FindElement(By.Id("loginLink"));
        public IWebElement lnkEmployeeList => _driver.FindElement(By.LinkText("Employee List"));
        public IWebElement txtUserName => _driver.FindElement(By.Name("UserName"));
        public IWebElement txtPassword => _driver.FindElement(By.Id("Password"));
        public IWebElement btnLogin => _driver.FindElement(By.CssSelector("input.btn"));

        public void Login(string username, string password)
        {
            txtUserName.SendKeys("admin");
            txtPassword.SendKeys("password");
            btnLogin.Submit();
        }

        public void ClickLoginLink()
        {
            lnkLogin.Click();
        }

        public EmployeePage ClickEmployeeList()
        {
            DriverContext.Driver.WaitForPageLoaded();
            lnkEmployeeList.Click();
            return GetInstance<EmployeePage>();
        }

        internal void CheckIfLoginExists()
        {
            txtUserName.AssertElementPresent();
        }
    }
}
