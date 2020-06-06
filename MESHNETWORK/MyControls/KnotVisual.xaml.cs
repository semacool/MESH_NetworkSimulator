using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using MESHNETWORK.Classes;

namespace MESHNETWORK.MyControls
{
    /// <summary>
    /// Логика взаимодействия для KnotVisual.xaml
    /// </summary>
    public partial class KnotVisual : UserControl, IKnotSave
    {

        #region Переменные для сохранения
        public static uint NextId = 0;
        public uint id { get; set; }
        public double xCord { get; set; }
        public double yCord { get; set; }
        public double radius { get; set; }
        public bool source { get; set; }
        public bool target { get; set; } 
        public string name { get; set; }
        #endregion

        /// <summary>
        /// Создание мышкой
        /// </summary>
        /// <param name="point"></param>
        public KnotVisual(Point point)
        {
            InitializeComponent();
            id = NextId++;
            xCord = point.X;
            yCord = point.Y;
            radius = Radius.Width;
            DataContext = Logic.Config;
            source = false;
            target = false;

            this.Loaded += KnotVisual_Loaded;
        }

        /// <summary>
        /// Создание из файла
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="XCord"></param>
        /// <param name="YCord"></param>
        /// <param name="Radius"></param>
        /// <param name="Source"></param>
        /// <param name="Target"></param>
        public KnotVisual(uint Id,string Name, double XCord, double YCord, double Radius,
                            bool Source = false, bool Target = false)
        {
            InitializeComponent();
            DataContext = Logic.Config;
            id = Id;
            xCord = XCord;
            yCord = YCord;
            radius = Radius;
            source = Source;
            target = Target;
            name = Name;
            
            this.Loaded += KnotVisual_Loaded;
        }

        /// <summary>
        /// Настойка внешнего вида
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KnotVisual_Loaded(object sender, RoutedEventArgs e)
        {
            Canvas.SetLeft(this, xCord);
            Canvas.SetTop(this, yCord);
            Radius.Width = radius;
            Radius.Height = radius;

            if (source) 
            {
                SourceSelect();
            }
            else if (target) 
            {
                TargetSelect();
            }
        }

        #region События мыши

        private void KnotVisual_MouseMove(object sender, MouseEventArgs e)
        {
            ChangePosition(e);
        }

        private void UserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CurrentSelect();
        }

        private void UserControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            StopMove();
        }

        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            StopMove();
        }

        private void UserControl_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            ChangeRadius(e);
        }

        private void UserControl_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SourceTargetLogic();
        }  
        #endregion

        #region Логика выбора типа узла
        private void SourceTargetLogic() 
        {
            if(Logic.SourceKnot == null || Equals(Logic.SourceKnot)) 
            {
                SourceSelect();
            }
            else 
            {
                TargetSelect();
            }

        }
        private void CurrentSelect() 
        {
            if (Logic.CurrentKnot != null)
            {
                if(!Logic.CurrentKnot.Equals(Logic.SourceKnot) && !Logic.CurrentKnot.Equals(Logic.TargetKnot))
                {
                    Logic.CurrentKnot.Radius.Style = Resources["RadiusOFF"] as Style;
                    Logic.CurrentKnot.Point.Style = Resources["Common"] as Style;
                }
            }

            StopMove();

            Logic.CurrentKnot = this;
            Logic.CurrentKnot.MouseMove += KnotVisual_MouseMove;
            Logic.CurrentKnot.Radius.Style = Resources["RadiusON"] as Style;

            if (!Equals(Logic.SourceKnot) && !Equals(Logic.TargetKnot))
            {
                Logic.CurrentKnot.Point.Style = Resources["Current"] as Style;
            }
        }
        private void SourceSelect()
        {   
            if(Logic.SourceKnot != null) 
            {
                Logic.SourceKnot.Point.Style = Resources["Common"] as Style;
                Logic.SourceKnot.Radius.Style = Resources["RadiusOFF"] as Style;
                Logic.SourceKnot.source = false;
                if (Equals(Logic.SourceKnot)) 
                {
                    TargetSelect();
                    Logic.SourceKnot = null;
                    return;
                }
            }

            Logic.SourceKnot = this;
            Logic.SourceKnot.Point.Style = Resources["Source"] as Style;
            Logic.SourceKnot.Radius.Style = Resources["RadiusON"] as Style;      
            Logic.SourceKnot.source = true;
        }
        private void TargetSelect()
        {
            if(Logic.TargetKnot != null) 
            {
                Logic.TargetKnot.Point.Style = Resources["Common"] as Style;
                Logic.TargetKnot.Radius.Style = Resources["RadiusOFF"] as Style;
                Logic.TargetKnot.target = false;

                if (Equals(Logic.TargetKnot) || Equals(Logic.SourceKnot))
                {
                    Logic.TargetKnot = null;
                    return;
                }
            }
            Logic.TargetKnot = this;
            Logic.TargetKnot.Point.Style = Resources["Target"] as Style;
            Logic.TargetKnot.target = true;
        }


        #endregion

        #region Изменение позиции и радиуса
        private void StopMove()
        {
            if (Logic.CurrentKnot != null)
            {
                Logic.CurrentKnot.MouseMove -= KnotVisual_MouseMove;
            }
            xCord = Canvas.GetLeft(this);
            yCord = Canvas.GetTop(this);
        }
        private void ChangeRadius(MouseWheelEventArgs e)
        {
            if (Equals(Logic.SourceKnot))
            {
                Radius.Width += Radius.Width <= 50 ? 1 : e.Delta / 25;
                Radius.Height += Radius.Height <= 50 ? 1 : e.Delta / 25;
                radius = Radius.Width;
            }
        }
        private void ChangePosition(MouseEventArgs e)
        {
            double x = e.GetPosition(Parent as Canvas).X;
            double y = e.GetPosition(Parent as Canvas).Y;

            if (x < (Parent as Canvas).Width && x > 0)
                    Canvas.SetLeft(this, x - Radius.Width / 2);

            if (y < (Parent as Canvas).Height && y > 0)
                    Canvas.SetTop(this, y - Radius.Width / 2);
        }
        #endregion
    }
}
