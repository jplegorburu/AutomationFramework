using System;
using EAAutoFramework.Base;
using EAAutoFramework.Config;
using EAAutoFramework.Helpers;
using EAEmployeeTest.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace Tests
{
    public class Tests : Base
    {

        public void OpenBrowser(BrowserType browserType = BrowserType.Firefox)
        {
            switch (browserType)
            {
                case BrowserType.InternetExplorer:
                    DriverContext.Driver = new InternetExplorerDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.Chrome:
                    DriverContext.Driver = new ChromeDriver("C:/Users/juan.legorburu/Downloads");
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.Firefox:
                    FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"C:/Users/juan.legorburu/Downloads");
                    service.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
                    DriverContext.Driver = new FirefoxDriver(service);
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
            }
        }


        [SetUp]
        public void Setup()
        {
            ConfigReader.SetFrameworkSettings();
        }

        [Test]
        public void Test1()
        {
            string filename = Environment.CurrentDirectory.ToString() + "\\Data\\Login.xlsx";
            ExcelHelpers.PopulateInCollection(filename);


            OpenBrowser(BrowserType.Firefox);
            DriverContext.Browser.GoToUrl(Settings.AUT);
            // Login Page
            CurrentPage = GetInstance<LoginPage>();
            CurrentPage.As<LoginPage>().ClickLoginLink();
            CurrentPage.As<LoginPage>().CheckIfLoginExists();
            CurrentPage.As<LoginPage>().Login(ExcelHelpers.ReadData(1,"UserName"), ExcelHelpers.ReadData(1, "Password"));
            // Employee Page
            CurrentPage = CurrentPage.As<LoginPage>().ClickEmployeeList();
            CurrentPage.As<EmployeePage>().ClickCreateNew();


        }

        [Test]
        public void TableOperation()
        {
            OpenBrowser(BrowserType.Firefox);
            DriverContext.Browser.GoToUrl(Settings.AUT);
            // Login Page
            CurrentPage = GetInstance<LoginPage>();
            CurrentPage.As<LoginPage>().ClickLoginLink();
            CurrentPage.As<LoginPage>().Login(ExcelHelpers.ReadData(1, "UserName"), ExcelHelpers.ReadData(1, "Password"));
            // Employee Page
            CurrentPage = CurrentPage.As<LoginPage>().ClickEmployeeList();
            var table = CurrentPage.As<EmployeePage>().GetEmployeeList();
            HtmlTableHelpers.ReadTable(table);
            HtmlTableHelpers.PerformActionOnCell("6", "Name", "Ramesh", "Edit");
        }

    }
}