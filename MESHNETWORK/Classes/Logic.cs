using MESHNETWORK.MyControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESHNETWORK.Classes
{
    /// <summary>
    /// Класс, через который идёт взаимодействие с программой
    /// </summary>
    class Logic
    {
        public static MainWindow w;

        public static Config Config { get; set; } = new Config();

        public static  Objects Objects { get; set; } = new Objects();

        public static JsonConvertFile Json { get; set; } = new JsonConvertFile();

        public static ServerS Server { get; set; } = new ServerS();

        public static Routers Router { get; set; } = new Routers();

        /// <summary>
        /// Очищение интерфейс данных  
        /// </summary>
        static  public void UpdateData()
        {
            SelectVisualKnot = null;
            TargetVisualKnot = null;
            SourceVisualKnot = null;
            Objects.Knots.Clear();
            Router.Knots.Clear();
        }

        #region Текущие активные Элементы
        public static KnotVisual SelectVisualKnot;
        public static KnotVisual TargetVisualKnot;
        public static KnotVisual SourceVisualKnot;
        #endregion
    }
}
