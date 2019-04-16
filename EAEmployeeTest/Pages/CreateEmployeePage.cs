using System;
using EAAutoFramework.Base;
using OpenQA.Selenium;

namespace EAEmployeeTest.Pages
{
    internal class CreateEmployeePage : BasePage
    {
        public IWebElement txtName => _driver.FindElement(By.Id("Name"));
        public IWebElement txtSalary => _driver.FindElement(By.Id("Salary"));
        public IWebElement txtDurationWorked => _driver.FindElement(By.Id("DurationWorked"));
        public IWebElement txtGrade => _driver.FindElement(By.Id("Grade"));
        public IWebElement txtEmail => _driver.FindElement(By.Id("Email"));
        public IWebElement btnCreate => _driver.FindElement(By.XPath("//input[@value='Create']"));

        internal void ClickCreateButton()
        {
            btnCreate.Submit();
        }

        internal void CreateEmployee(string name, string salary, string durationWorked, string grade, dynamic email)
        {
            txtName.SendKeys(name);
            txtSalary.SendKeys(salary);
            txtDurationWorked.SendKeys(durationWorked);
            txtGrade.SendKeys(grade);
            txtEmail.SendKeys(email);

        }
    }
}
