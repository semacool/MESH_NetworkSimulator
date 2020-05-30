using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESHNETWORK.Classes
{
    /// <summary>
    /// Класс Узла
    /// </summary>
    class KnotSave : IKnotSave
    {
        public static uint NextId = 0;
        public uint id { get; set; }
        public double xCord { get; set; }
        public double yCord { get; set; }
        public double radius { get; set; }
        public bool source { get; set; }
        public bool target { get; set; }

        public KnotSave(uint Id, double XCord, double YCord, double Radius, bool Source, bool Target) 
        {
            id = NextId++;
            xCord = XCord;
            yCord = YCord;
            radius = Radius;
            source = Source;
            target = Target;
        }
    }
}
