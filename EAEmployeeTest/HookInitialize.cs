using EAAutoFramework.Base;
using EAAutoFramework.Config;
using EAAutoFramework.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace EAEmployeeTest
{
    [Binding]
    public class HookInitialize : TestInitializeHook
    {
        public HookInitialize() : base(BrowserType.Firefox)
        {
            InitializeSettings();
            // NavigateSite();
            // Settings.ApplicationCon = Settings.ApplicationCon.DBConnect(Settings.AppConnectionString);
        }

        [BeforeFeature]
        public static void TestStart()
        {
            HookInitialize init = new HookInitialize();
        }

        [AfterScenario]
        public static void TestStop()
        {
            DriverContext.Driver.Quit();
        }


    }
}
