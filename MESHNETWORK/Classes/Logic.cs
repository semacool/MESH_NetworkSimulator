﻿using System;
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
        public static  Config Config = new Config();

        public static  Objects Objects = new Objects();

        public static JsonConvertFile Json = new JsonConvertFile();

        #region Текущие активные Элементы
        public static MyControls.KnotVisual SourceKnot;
        public static MyControls.KnotVisual CurrentKnot;
        public static MyControls.KnotVisual TargetKnot; 
        #endregion
    }
}