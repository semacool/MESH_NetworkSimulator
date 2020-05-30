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

            if (typeof(T) == typeof(IKnotSave))
            {
                main["NextIndex"] = Logic.Objects.Knots.Count;
                main["Knots"] = JArray.FromObject(List);
            }

            string json = main.ToString();
            File.WriteAllText(Path, json);
        }

        public void OpenFile<T>(string Path) 
        {
            string json = File.ReadAllText(Path);

            if(typeof(T) == typeof(KnotSave)) 
            {
                KnotVisual.NextId = JObject.Parse(json)["NextIndex"].Value<uint>();

                IEnumerable<IKnotSave> enumerable = 
                    JsonConvert.DeserializeObject<List<KnotSave>>(JObject.Parse(json)["Knots"].ToString()); //Ковариантность

                Logic.Objects.KnotsSave = enumerable.ToList();
            }
        }
    }
}
