using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;

namespace EAAutoFramework.Base
{
    public abstract class BasePage : Base
    {

        public BasePage()
        {
            PageFactory.InitElements(DriverContext.Driver, this);
        }


    }

}