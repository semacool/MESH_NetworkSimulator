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

        #region Узлы
        public List<IKnotSave> Knots { get; set; }

        /// <summary>
        /// Колекция для сохранения
        /// </summary>
        public List<IKnotSave> KnotsSave
        {
            get
            {
                List<IKnotSave> ts = new List<IKnotSave>();
                foreach (IKnotSave knot in Knots)
                {
                    ts.Add(new KnotSave(knot.id, knot.xCord, knot.yCord, knot.radius, knot.source, knot.target));
                }
                return ts;
            }

            set
            {
                List<IKnotSave> tv = new List<IKnotSave>();
                foreach (IKnotSave knot in value)
                {
                    tv.Add(new KnotVisual(knot.id, knot.xCord, knot.yCord, knot.radius, knot.source, knot.target));
                }

                Knots = tv;
            }
        } 
        #endregion

        public Objects()
        {
            Knots = new List<IKnotSave>();
        }

        
        
    }
}
