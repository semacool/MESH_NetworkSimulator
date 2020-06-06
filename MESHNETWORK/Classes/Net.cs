using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESHNETWORK.Classes
{
    /// <summary>
    /// Класс для представление схемы
    /// </summary>
    class Net
    {
        public string name{ get; set; }
        public int countNodes { get; set; }
        public string author { get; set; }
        public string access { get; set; }

        public List<IKnotSave> knotSaves { get; set; }

        public Net(string Name, int CountSaves, string Author, string Access)
        {
            name = Name;
            countNodes = CountSaves;
            author = Author;
            access = Access;
            knotSaves = new List<IKnotSave>();
        }

        public Net(string Name, List<IKnotSave> KnotSaves, string Author, string Access) 
        {
            name = Name;
            countNodes = KnotSaves.Count;
            author = Author;
            access = Access;
            knotSaves = KnotSaves;
        }
        public Net(string Name, List<IKnotSave> KnotSaves)
        {
            name = Name;
            countNodes = KnotSaves.Count;
            knotSaves = KnotSaves;
        }
    }
}
