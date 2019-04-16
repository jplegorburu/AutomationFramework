using EAAutoFramework.Base;
using EAAutoFramework.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace EAEmployeeTest.Pages
{
    internal class HomePage : BasePage
    {
        public IWebElement lnkLogin => _driver.FindElement(By.Id("loginLink"));
        public IWebElement lnkEmployeeList => _driver.FindElement(By.LinkText("Employee List"));
        public IWebElement lnkLoggedInUser => _driver.FindElement(By.XPath("//a[@title='Manage']"));
        public IWebElement lnkLogoff => _driver.FindElement(By.LinkText("Log off"));

        public LoginPage ClickLoginLink()
        {
            lnkLogin.Click();
            return GetInstance<LoginPage>();
        }

        internal void CheckIfLoginExists()
        {
            lnkLogin.AssertElementPresent();
        }

        public EmployeeListPage ClickEmployeeList()
        {
            DriverContext.Driver.WaitForPageLoaded();
            lnkEmployeeList.Click();
            return GetInstance<EmployeeListPage>();
        }

        internal string GetLoggedInUser()
        {
            return lnkLoggedInUser.GetLinkText();
        }

    }
}
