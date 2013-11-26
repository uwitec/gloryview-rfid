using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;
using System.IO;

namespace GloryView.RFID.SystemManagement.SystemClass
{
    class DatabaseBackupAndRestore
    {
        //public static void DoBackup()
        //{
        //    //string[] ary = ReadFromText();

        //    //string host = ary[0];
        //    //string port = ary[1];
        //    //string user = ary[2];
        //    //string password = ary[3];
        //    //string database = ary[4];
        //    //string fileName = database + "_bak_" + DateTime.Now.ToString("yyyyMMddhhmmss");
        //    //string bakPath = ary[5] + "\\" + fileName + ".sql";
        //    //string logPath = ary[6];

        //    string cmdStr = "/c mysqldump -h" + host + " -P" + port + " -u" + user + " -p" + password + " " + database + " > " + bakPath;


        //    try
        //    {
        //        System.Diagnostics.Process.Start("cmd", cmdStr);
        //    }
        //    catch (Exception ex)
        //    {
        //        WriteLog(logPath, ex.Message);
        //    }

        //}
        /// <summary>
        /// 读配置
        /// </summary>
        /// <returns></returns>
        public static string[] ReadFromText()
        {
            string FileName = @"d:\BackupIni.txt";
            ArrayList list = new ArrayList();
            if (File.Exists(FileName))
            {
                StreamReader sr = new StreamReader(FileName, Encoding.Default);
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    list.Add(s);
                }
            }
            return (string[])list.ToArray(typeof(string));
        }
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="theStr"></param>
        public static void WriteLog(string filePath, string theStr)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }
            StreamWriter sw = new StreamWriter(filePath, true, Encoding.Default);
            sw.WriteLine(theStr);
            sw.Flush();
            sw.Close();
        }


    }
}
