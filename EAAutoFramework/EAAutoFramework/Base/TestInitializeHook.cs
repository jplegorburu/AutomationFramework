using EAAutoFramework.Config;
using EAAutoFramework.Helpers;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
namespace EAAutoFramework.Base
{
    public abstract class TestInitializeHook : Base
    {
        public readonly BrowserType Browser;

        public TestInitializeHook(BrowserType browser)
        {
            Browser = browser;
        }

        public void InitializeSettings()
        {
            // Set all the settings for the frame work
            ConfigReader.SetFrameworkSettings();
            // Set log
            LogHelpers.CreateLogFile();
            // Open browser
            OpenBrowser(Browser);
            LogHelpers.Write("Opened browser!!");
        }

        private void OpenBrowser(BrowserType browserType = BrowserType.Firefox)
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

        public virtual void NavigateSite()
        {
            DriverContext.Browser.GoToUrl(Settings.AUT);
            LogHelpers.Write(string.Format("Navigated to site {0}!!", Settings.AUT));

        }
    }
}
