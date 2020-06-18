using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MESHNETWORK.MyControls;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MESHNETWORK.Classes
{
    /// <summary>
    /// Класс для сохранения и открытия файлов
    /// </summary>
    class JsonConvertFile
    {
        string path { get; set; }

        public void SaveFile<T>(List<T> List, string Path) 
        {
            JObject main = new JObject();

            if (typeof(T) == typeof(KnotSave))
            {
                main["NextIndex"] = Logic.Objects.Knots.Count;
                main["Knots"] = JArray.FromObject(List);
                KnotSave.NextId = 0;
            }

            string json = main.ToString();
            File.WriteAllText(Path, json);
        }

        public void OpenFile(string Path) 
        {
            string json = File.ReadAllText(Path);

                KnotSave.NextId = JObject.Parse(json)["NextIndex"].Value<uint>();

                Logic.Objects.Knots = JsonConvert.DeserializeObject<List<KnotSave>>
                    (
                        JObject.Parse(json)["Knots"].ToString()
                    ); 
        }
    }
}
