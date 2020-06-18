﻿using MESHNETWORK.MyControls;
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

        public static  Config Config = new Config();

        public static  Objects Objects = new Objects();

        public static JsonConvertFile Json = new JsonConvertFile();

        public static ServerS Server = new ServerS();

        /// <summary>
        /// Очищение интерфейс данных  
        /// </summary>
        static  public void UpdateData()
        {
            SelectVisualKnot = null;
            TargetVisualKnot = null;
            SourceVisualKnot = null;
            Objects.Knots.Clear();
        }

        #region Текущие активные Элементы
        public static KnotVisual SelectVisualKnot;
        public static KnotVisual TargetVisualKnot;
        public static KnotVisual SourceVisualKnot;
        #endregion
    }
}
