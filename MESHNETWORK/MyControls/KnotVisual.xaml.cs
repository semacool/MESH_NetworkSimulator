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
    public partial class KnotVisual : UserControl
    {
        public KnotSave ks;
        public KnotVisual(KnotSave Ks)
        {
            InitializeComponent();
            DataContext = new DataContextForNode(Ks);
            ks = Ks;
            this.Loaded += KnotVisual_Loaded;
        }

        /// <summary>
        /// Настойка внешнего вида
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KnotVisual_Loaded(object sender, RoutedEventArgs e)
        {
            Canvas.SetLeft(this, ks.CordX);
            Canvas.SetTop(this, ks.CordY);
            switch (ks.typeNode)
            {
                case TypeNode.common:
                    Point.Style = Resources["Common"] as Style;
                    break;
                case TypeNode.source:
                    Point.Style = Resources["Source"] as Style;
                    break;
                case TypeNode.target:
                    Point.Style = Resources["Target"] as Style;
                    break;
            }
            Binding CordinateX = new Binding("CordX");
            CordinateX.Source = ks;
            Binding CordinateY = new Binding("CordY");
            CordinateY.Source = ks;
            this.SetBinding(Canvas.LeftProperty, CordinateX);
            this.SetBinding(Canvas.TopProperty, CordinateY);
        }

        #region События мыши
        private void KnotVisual_MouseMove(object sender, MouseEventArgs e)
        {
            ChangePosition(e);
        }

        private void UserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.MouseMove += KnotVisual_MouseMove;
            Logic.SelectVisualKnot = this;
            this.SetValue(Canvas.ZIndexProperty, 3);
            Logic.w.DataContext = this.ks;
        }

        private void UserControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.SetValue(Canvas.ZIndexProperty, 2);
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
            if (Logic.SourceVisualKnot == null) 
            {
                SelectSource();
            }
            else if(Logic.SourceVisualKnot == this)
            {
                ClearSource();
            }
            else
            {
                if (Logic.TargetVisualKnot == null)
                {
                    SelectTarget();
                }
                else if (Logic.TargetVisualKnot == this)
                {
                    ClearTarget();
                }
                else
                {
                    ClearTarget();
                    SelectTarget();
                }
            }
        }
        #endregion

        #region Повторяющийся код
        private void ClearSource()
        {
            Logic.SourceVisualKnot.ks.typeNode = TypeNode.common;
            Logic.SourceVisualKnot.Point.Style = Resources["Common"] as Style;
            Logic.SourceVisualKnot = null;

            if (Logic.TargetVisualKnot != null)
                ClearTarget();
        }
        private void SelectSource()
        {
            Logic.SourceVisualKnot = this;
            Logic.SourceVisualKnot.ks.typeNode = TypeNode.source;
            Logic.SourceVisualKnot.Point.Style = Resources["Source"] as Style;
        }
        private void ClearTarget()
        {
            Logic.TargetVisualKnot.ks.typeNode = TypeNode.common;
            Logic.TargetVisualKnot.Point.Style = Resources["Common"] as Style;
            Logic.TargetVisualKnot = null;
        }
        private void SelectTarget()
        {
            Logic.TargetVisualKnot = this;
            Logic.TargetVisualKnot.ks.typeNode = TypeNode.target;
            Logic.TargetVisualKnot.Point.Style = Resources["Target"] as Style;
        } 
        #endregion

        #region Изменение позиции и радиуса
        private void StopMove()
        {
              this.MouseMove -= KnotVisual_MouseMove;
        }
        private void ChangeRadius(MouseWheelEventArgs e)
        {
            if (this.Equals(Logic.SelectVisualKnot))
            {
                ks.Radius += Radius.Width <= 50 ? 1 : e.Delta / 25;
            }
        }
        private void ChangePosition(MouseEventArgs e)
        {
            double x = e.GetPosition(Parent as Canvas).X;
            double y = e.GetPosition(Parent as Canvas).Y;

            if (x < (Parent as Canvas).Width && x > 0) 
            {
                ks.CordX = x;
            }
            if (y < (Parent as Canvas).Height && y > 0) 
            {
                ks.CordY = y;
            }
        }
        #endregion
    }
}
