using System;
using EAAutoFramework.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace EAEmployeeTest.Pages
{
    public class EmployeePage : BasePage
    {
        public EmployeePage()
        {
        }

        private IWebElement txtSearch => _driver.FindElement(By.Name("searchTerm"));
        private IWebElement lnkCreateNew => _driver.FindElement(By.LinkText("Create New"));
        private IWebElement tblEmployeeList => _driver.FindElement(By.ClassName("table"));

        public CreateEmployeePage ClickCreateNew()
        {
            lnkCreateNew.Click();
            return new CreateEmployeePage();
        }

        public IWebElement GetEmployeeList()
        {
            return tblEmployeeList;
        }

    }
}
