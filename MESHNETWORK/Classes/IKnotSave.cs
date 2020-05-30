using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESHNETWORK.Classes
{
    /// <summary>
    /// Вспомогательный интерфейс
    /// </summary>
    interface IKnotSave
    {
        uint id { get; set; }
        double xCord { get; set; }
        double yCord { get; set; }
        double radius { get; set; }
        bool source { get; set; }
        bool target { get; set; }
    }
}
