using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace REST_StudentCollege
{
    public class FileLogger
    {
        public static void WriteLog(string e)
        {
            string strFileName;
            string strLog;
            string strDirectoryPath = ".\\Error\\";
            StreamWriter swlog = null;
            DateTime currentLog = DateTime.Now;

            // Generate File Name Based on Date.
            strFileName = strDirectoryPath + "ErrorLogging" + currentLog.Year.ToString().PadLeft(4, '0') +
                currentLog.Month.ToString().PadLeft(2, '0') + currentLog.Day.ToString().PadLeft(2, '0') + ".txt";

            strLog = string.Format("[{0}]: {1}", currentLog.Day.ToString().PadLeft(2, '0') + "/" +
                currentLog.Month.ToString().PadLeft(2, '0') + "/" + currentLog.Year.ToString().PadLeft(4, '0') + " " +
                currentLog.Hour.ToString().PadLeft(2, '0') + ":" + currentLog.Minute.ToString().PadLeft(2, '0') + ":" +
                currentLog.Second.ToString().PadLeft(2, '0'), e);

            if (!Directory.Exists(strDirectoryPath))
            {
                Directory.CreateDirectory(strDirectoryPath);
            }

            if (!File.Exists(strFileName))
            {
                swlog = new StreamWriter(strFileName);
            }
            else
            {
                swlog = File.AppendText(strFileName);
            }

            swlog.WriteLine(strLog);
            swlog.Close();

        }
    }
}
