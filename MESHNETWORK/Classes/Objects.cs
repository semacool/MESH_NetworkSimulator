using MESHNETWORK.MyControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESHNETWORK.Classes
{
    /// <summary>
    /// Класс, для хранения элементов
    /// </summary>
    class Objects
    {
        public List<KnotSave> Knots { get; set; }

        public List<Net> Nets { get; set; }

        public Objects()
        {
            Knots = new List<KnotSave>();
            Nets = new List<Net>();
        }      
    }
}