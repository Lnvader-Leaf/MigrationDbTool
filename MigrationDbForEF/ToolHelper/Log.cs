using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using MigrationDbForEF.Mould;

namespace MigrationDbForEF.ToolHelper
{
    public class Log
    {
        static Mutex mutLog = new Mutex();

        //保存系统日志
        public void SaveLog(string message)
        {
            //获得所有文本
            string strLog = message;

            try
            {
                mutLog.WaitOne();

                //Dictionary Name
                string strDicName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"Log\", DateTime.Now.ToString("yyyy-MM-dd"));
                //Whether Exists
                DirectoryInfo dicInfo = new DirectoryInfo(strDicName);
                if (!dicInfo.Exists)
                {
                    dicInfo.Create();
                }

                //File Count
                int intLength = dicInfo.GetFiles("*.log").Length;

                FileInfo fileInfo = null;
                if (intLength == 0)
                {
                    fileInfo = new FileInfo(Path.Combine(strDicName, intLength.ToString() + ".log"));
                    using (FileStream fileStream = fileInfo.Create())
                    {
                        fileStream.Close();
                        fileStream.Dispose();
                    }
                }
                else
                {
                    var dataPath = dicInfo.GetFiles("*.log").OrderBy(m=>m.CreationTime).ToArray();
                    //Get File
                    fileInfo = dataPath[intLength - 1];
                    //Check Size
                    if (fileInfo.Length > 100000)
                    {
                        fileInfo = new FileInfo(Path.Combine(strDicName, intLength.ToString() + ".log"));
                        using (FileStream fileStream = fileInfo.Create())
                        {
                            fileStream.Close();
                            fileStream.Dispose();
                        }
                    }
                }

                //Write Text File
                using (StreamWriter writer = new StreamWriter(fileInfo.FullName, true))
                {
                    writer.WriteLine(strLog);
                    writer.Close();
                    writer.Dispose();
                }
            }
            finally
            {
                mutLog.ReleaseMutex();
            }
        }
        public async Task<bool> deleteDic(int logTime)
        {
            var interfaceLog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory  + @"InterfaceLog");// + @"InterfaceLog");
            var sysLog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"Log");//+ @"Log");
            DirectoryInfo dicInfo1 = new DirectoryInfo(interfaceLog);
            DirectoryInfo dicInfo2 = new DirectoryInfo(sysLog);
            FileSystemInfo[] fsinfos1 = dicInfo1.GetFileSystemInfos();
            FileSystemInfo[] fsinfos2 = dicInfo2.GetFileSystemInfos();
            DateTime datetime = DateTime.Now.AddDays(-logTime);
            foreach (var item in fsinfos2)
            {
                string[] str1 = item.ToString().Split(@"\");
                var comparison_time = Convert.ToDateTime(str1[str1.Length - 1]);
                if (comparison_time < datetime)
                {
                    var dicTimes = Convert.ToDateTime(str1[str1.Length - 1]).ToString("yyyy-MM-dd");
                    DirectoryInfo dicinfo = new DirectoryInfo(sysLog + "\\" + dicTimes);
                    int fileLength1 = dicinfo.GetFiles("*.log").Length;
                    if (fileLength1 == 0)
                    {
                        item.Delete();
                    }
                    else
                    {
                        for (int j = 0; j < fileLength1; j++)
                        {
                            FileInfo fileInfo = new FileInfo(Path.Combine(item.FullName, j + ".log"));
                            fileInfo.Delete();
                        }
                    }

                    //dicinfo.Delete();
                    item.Delete();
                }
            }
            foreach (var item in fsinfos1)
            {
                string[] str1 = item.ToString().Split(@"\");
                var comparison_time = Convert.ToDateTime(str1[str1.Length - 1]);
                if (comparison_time < datetime)
                {
                    var dicTimes = Convert.ToDateTime(str1[str1.Length - 1]).ToString("yyyy-MM-dd");
                    DirectoryInfo dicinfo = new DirectoryInfo(interfaceLog + "\\" + dicTimes);
                    int fileLength1 = dicinfo.GetFiles("*.log").Length;
                    if (fileLength1 == 0)
                    {
                        item.Delete();
                    }
                    else
                    {
                        for (int j = 0; j < fileLength1; j++)
                        {
                            FileInfo fileInfo = new FileInfo(Path.Combine(item.FullName, j + ".log"));
                            fileInfo.Delete();
                        }
                    }

                    //dicinfo.Delete();
                    item.Delete();
                }
            }
            return true;
        }
        //保存接口日志
        public void SaveInterfaceLog(string message)
        {
            //获得所有文本
            string strLog = message;

            try
            {
                mutLog.WaitOne();

                //Dictionary Name
                string strDicName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"InterfaceLog\", DateTime.Now.ToString("yyyy-MM-dd"));
                //Whether Exists
                DirectoryInfo dicInfo = new DirectoryInfo(strDicName);
                if (!dicInfo.Exists)
                {
                    dicInfo.Create();
                }

                //File Count
                int intLength = dicInfo.GetFiles("*.log").Length;

                FileInfo fileInfo = null;
                if (intLength == 0)
                {
                    fileInfo = new FileInfo(Path.Combine(strDicName, intLength.ToString() + ".log"));
                    using (FileStream fileStream = fileInfo.Create())
                    {
                        fileStream.Close();
                        fileStream.Dispose();
                    }
                }
                else
                {
                    //Get File
                    var dataPath = dicInfo.GetFiles("*.log").OrderBy(m => m.CreationTime).ToArray();
                    //Get File
                    fileInfo = dataPath[intLength - 1];
                    //Check Size
                    if (fileInfo.Length > 100000)
                    {
                        fileInfo = new FileInfo(Path.Combine(strDicName, intLength.ToString() + ".log"));
                        using (FileStream fileStream = fileInfo.Create())
                        {
                            fileStream.Close();
                            fileStream.Dispose();
                        }
                    }
                }

                //Write Text File
                using (StreamWriter writer = new StreamWriter(fileInfo.FullName, true))
                {
                    writer.WriteLine(strLog);
                    writer.Close();
                    writer.Dispose();
                }
            }
            finally
            {
                mutLog.ReleaseMutex();
            }
        }

        //读取日志
        public async Task<IEnumerable<Log_Read_Data>> ReadLog(string log_type, string start_time, string end_time)
        {
            string pathName = string.Empty;

            try
            {
                DateTime time_start = Convert.ToDateTime(start_time);
                DateTime time_end = Convert.ToDateTime(end_time);
                string line;
                List<Log_Read_Data> readData = new List<Log_Read_Data>();
                if (log_type == "I")
                {
                    //接口日志
                    pathName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"InterfaceLog");
                }
                else
                {
                    //系统日志
                    pathName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"Log");
                }

                DirectoryInfo dicInfo2 = new DirectoryInfo(pathName);
                if (!dicInfo2.Exists)
                {
                    return readData;
                }
                FileSystemInfo[] fsinfos = dicInfo2.GetFileSystemInfos();

                foreach (FileSystemInfo item in fsinfos)
                {
                    string[] str1 = item.ToString().Split(@"\");

                    DateTime comparison_time = Convert.ToDateTime(str1[str1.Length - 1]);
                    if (comparison_time >= time_start && comparison_time <= time_end)
                    {
                        DirectoryInfo fileinfo = new DirectoryInfo(item.FullName);
                        int fileLength = fileinfo.GetFiles("*.log").Length;
                        if (fileLength == 0)
                        {
                            continue;
                        }
                        for (int i = 0; i < fileLength; i++)
                        {
                            FileInfo fileInfo = new FileInfo(Path.Combine(item.FullName, i + ".log"));
                            using (StreamReader writer = new StreamReader(fileInfo.FullName, true))
                            {
                                while ((line = await writer.ReadLineAsync()) != null)
                                {
                                    var LogData = JsonConvert.DeserializeObject<Log_Read_Data>(line);
                                    if (LogData.In_parameter != null && LogData.In_parameter.Length > 150)
                                    {
                                        int count = (LogData.In_parameter.Length / 150);
                                        int insertCount = 0;
                                        for (int j = 0; j < count; j++)
                                        {
                                            insertCount += 150;
                                            LogData.In_parameter = LogData.In_parameter.Insert(insertCount, "\r\n");
                                        }
                                    }
                                    if (LogData.Out_parameter != null && LogData.Out_parameter.Length > 150)
                                    {
                                        int count = (LogData.Out_parameter.Length / 150);
                                        int insertCount = 0;
                                        for (int j = 0; j < count; j++)
                                        {
                                            insertCount += 150;
                                            LogData.Out_parameter = LogData.Out_parameter.Insert(insertCount, "\r\n");
                                        }
                                    }
                                    readData.Add(LogData);
                                }
                                writer.Close();
                                writer.Dispose();
                            }
                        }
                    }
                }
                return readData;
            }
            finally
            {
            }
        }

        //清除AGV通讯记录,保留一个月的记录
        public void ClearAGVLog()
        {
            string strDicName = AppDomain.CurrentDomain.BaseDirectory + @"Log\";
            try
            {
                foreach (string strDic in Directory.GetDirectories(strDicName))
                {
                    DateTime dateNow = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                    DirectoryInfo dicInfo = new DirectoryInfo(strDic);
                    string dicName = dicInfo.Name;
                    if (Convert.ToDateTime(dicInfo.Name).AddDays(30) < dateNow)
                    {
                        dicInfo.Delete(true);
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
    }
}
