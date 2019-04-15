using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support;

namespace EAAutoFramework.Base
{
    public abstract class BasePage : Base
    {
        protected readonly IWebDriver _driver;
        public BasePage() => _driver = DriverContext.Driver;


    }

}