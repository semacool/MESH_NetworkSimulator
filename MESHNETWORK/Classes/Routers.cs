using MESHNETWORK.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;
using System.Windows.Threading;

namespace MESHNETWORK.Classes
{
    class Routers
    {
        public List<RouterKnot> Knots { get; set; } //Узлы-Роутеры
        public DispatcherTimer timer; //Таймер
        public Routers()
        {
            Knots = new List<RouterKnot>();
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(Logic.Config.SpeedSecond);
        }

        /// <summary>
        /// Тик таймера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Interval = TimeSpan.FromSeconds(Logic.Config.SpeedSecond);
            Scanning();
        }

        /// <summary>
        /// Создания узлов-роутеров для всех узлов
        /// </summary>
        public void CreateAll()
        {
            foreach (KnotSave ks in Logic.Objects.Knots)
            {
                Knots.Add(new RouterKnot(ks));
            }
        }

        public void Start() => timer.Start();

        public void Scanning()
        {
            CheckIn();
            CheckOut();
        }

        private void CheckIn()
        {
            List<RouterKnot> routerKnots = Knots.FindAll(n => n.MesIn.Count > 0);

            foreach (RouterKnot r in routerKnots)
            {
                r.ProcessIn();
            }
        }

        private void CheckOut()
        {
            List<RouterKnot> routerKnots = Knots.FindAll(n => n.MesOut.Count > 0);

            foreach (RouterKnot r in routerKnots)
            {
                r.SentMessage();
            }
        }
    }
}
