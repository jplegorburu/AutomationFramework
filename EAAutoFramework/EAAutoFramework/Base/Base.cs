using System;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace EAAutoFramework.Base
{

    public class Base
    {
        private IWebDriver _driver { get; set; }

        public BasePage CurrentPage
        {
            get => (BasePage)ScenarioContext.Current["currentPage"];
            set => ScenarioContext.Current["currentPage"] = value;
        }

        protected TPage GetInstance<TPage>() where TPage : BasePage, new()
        {
            TPage pageInstance = new TPage
            {
                _driver = DriverContext.Driver
            };
            return pageInstance;
        }

        public TPage As<TPage>() where TPage : BasePage
        {
            return (TPage)this;
        }
    }

}
