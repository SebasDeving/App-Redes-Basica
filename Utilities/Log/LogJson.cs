using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace POO.Utilities.Log
{
    public class LogJson : ILog<LogObject>, ILog<string>
    {
        public void SaveLog(LogObject action)
        {
            string logPath = Directory.GetCurrentDirectory() + @"/Log.json";
            var currentContent = string.Empty;

            var logObjects = new List<LogObject>();

            if (File.Exists(logPath))
            {
                //LECTURA DEL ARCHIVO
                var streamReader = new StreamReader(logPath);
                currentContent = streamReader.ReadToEnd();
                streamReader.Close();

                if (!string.IsNullOrEmpty(currentContent))
                {
                    logObjects = JsonConvert.DeserializeObject<List<LogObject>>(currentContent) ?? new List<LogObject>();
                }
            }

            //ESCRITURA DEL ARCHIVO
            var streamWriter = new StreamWriter(logPath);

            logObjects.Add(action);

            var jsonResult = JsonConvert.SerializeObject(logObjects);

            streamWriter.WriteLine(jsonResult);
            streamWriter.Close();
        }

        public void SaveLog(string action)
        {
            string logPath = Directory.GetCurrentDirectory() + @"/Log.json";
            var currentContent = string.Empty;

            var logObjects = new List<LogObject>();

            if (File.Exists(logPath))
            {
                //LECTURA DEL ARCHIVO
                var streamReader = new StreamReader(logPath);
                currentContent = streamReader.ReadToEnd();
                streamReader.Close();

                if (!string.IsNullOrEmpty(currentContent))
                {
                    logObjects = JsonConvert.DeserializeObject<List<LogObject>>(currentContent) ?? new List<LogObject>();
                }
            }

            //ESCRITURA DEL ARCHIVO
            var streamWriter = new StreamWriter(logPath);

            logObjects.Add(new LogObject() { Action = action, LogDate = DateTime.Now});

            var jsonResult = JsonConvert.SerializeObject(logObjects);

            streamWriter.WriteLine(jsonResult);
            streamWriter.Close();
        }
    }
}

 

