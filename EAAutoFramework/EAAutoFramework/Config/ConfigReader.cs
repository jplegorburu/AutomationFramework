using System;
using System.IO;
using System.Xml.XPath;
namespace EAAutoFramework.Config
{
    public class ConfigReader
    {

        public static void SetFrameworkSettings()
        {
            XPathItem aut;
            XPathItem testtype;
            XPathItem buildName;
            XPathItem isLog;
            XPathItem isReport;
            XPathItem logPath;
            XPathItem appConnection;

            string stringFileName = Environment.CurrentDirectory.ToString() + "\\Config\\GlobalConfig.xml";
            FileStream stream = new FileStream(stringFileName, FileMode.Open);
            XPathDocument document = new XPathDocument(stream);
            XPathNavigator navigator = document.CreateNavigator();

            // Get XMl Details and pass it in XPathItem type variables
            string rootPath = "EAAutoFramework/RunSettings/";
            aut = navigator.SelectSingleNode(rootPath+"AUT");
            testtype = navigator.SelectSingleNode(rootPath + "TestType");
            buildName = navigator.SelectSingleNode(rootPath + "BuildName");
            isLog = navigator.SelectSingleNode(rootPath + "IsLog");
            isReport = navigator.SelectSingleNode(rootPath + "IsReport");
            logPath = navigator.SelectSingleNode(rootPath + "LogPath");
            appConnection = navigator.SelectSingleNode(rootPath + "ApplicationDB");

            // Set XML Details in the property to be used across the Framework
            Settings.AUT = aut.Value.ToString();
            Settings.Build = buildName.Value.ToString();
            Settings.IsLog = isLog.Value.ToString();
            Settings.TestType = testtype.Value.ToString();
            Settings.IsReporting = isReport.Value.ToString();
            Settings.LogPath = logPath.Value.ToString();
            Settings.AppConnectionString = appConnection.Value.ToString();

        }

    }
}
