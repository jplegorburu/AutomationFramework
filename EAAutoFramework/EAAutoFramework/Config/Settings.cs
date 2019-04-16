using EAAutoFramework.Base;
using System;
using System.Data.SqlClient;

namespace EAAutoFramework.Config
{
    public class Settings
    {

        public static string TestType { get; set; }
        public static string AUT { get; set; }
        public static string Build { get; set; }
        public static BrowserType BrowserType { get; set; }
        public static string IsLog { get; set; }
        public static string IsReporting { get; set; }
        public static string LogPath { get; set; }
        public static SqlConnection ApplicationCon { get; set; }
        public static string AppConnectionString { get; set; }
    }
}
