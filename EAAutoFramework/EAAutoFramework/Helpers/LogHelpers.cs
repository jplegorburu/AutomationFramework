using EAAutoFramework.Config;
using System;
using System.IO;

namespace EAAutoFramework.Helpers
{
    public class LogHelpers
    {
        // Global declaration
        private static string _logFileName = string.Format("{0:yyyymmddhhmmss}", DateTime.Now);
        private static StreamWriter _streamw = null;


        // Create a file which can store log information
        public static void CreateLogFile()
        {
            string dir = Settings.LogPath;
            if (Directory.Exists(dir))
            {
                _streamw = File.AppendText(dir + _logFileName + ".log");
            }
            else
            {
                Directory.CreateDirectory(dir);
                _streamw = File.AppendText(dir + _logFileName + ".log");
            }
        }

        // Create a method which can write the text in the log file
        public static void Write(string logmessage)
        {
            _streamw.Write("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongTimeString());
            _streamw.WriteLine("\t\t {0}", logmessage);
            _streamw.Flush();
        }

    }
}
