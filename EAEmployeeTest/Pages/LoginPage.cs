using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAAutoFramework.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace EAEmployeeTest.Pages
{
    public class LoginPage : BasePage
    {
        //Initialize page login
        public LoginPage()
        {
        }

        [FindsBy(How = How.LinkText, Using = "Log in")]
        IWebElement lnkLogin { get; set; }

        [FindsBy(How = How.LinkText, Using = "Employee List")]
        IWebElement lnkEmployeeList { get; set; }

        [FindsBy(How = How.Id, Using = "UserName")]
        IWebElement txtUserName { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        IWebElement txtPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input.btn")]
        IWebElement btnLogin { get; set; }

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
            lnkEmployeeList.Click();
            return GetInstance<EmployeePage>();
        }
    }
}
