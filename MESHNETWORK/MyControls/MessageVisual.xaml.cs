using MESHNETWORK.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MESHNETWORK.MyControls
{
    /// <summary>
    /// Логика взаимодействия для MessageVisual.xaml
    /// </summary>
    public partial class MessageVisual : UserControl
    {
        private Storyboard myStoryboard;

        public Point Start { get; set; }
        public Point End { get; set; }

        public MessageVisual(Point Start, Point End)
        {
            InitializeComponent();
            this.Start = Start;
            this.End = End;
            this.Loaded += MessageVisual_Loaded;
        }

        private void MessageVisual_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation MessageAnimationX = new DoubleAnimation();
            MessageAnimationX.From = Start.X;
            MessageAnimationX.To = End.X;
            MessageAnimationX.Duration = new Duration(TimeSpan.FromSeconds(Logic.Config.SpeedSecond));

            DoubleAnimation MessageAnimationY = new DoubleAnimation();
            MessageAnimationY.From = Start.Y;
            MessageAnimationY.To = End.Y;
            MessageAnimationY.Duration = new Duration(TimeSpan.FromSeconds(Logic.Config.SpeedSecond));

            myStoryboard = new Storyboard();
            myStoryboard.Children.Add(MessageAnimationX);
            myStoryboard.Children.Add(MessageAnimationY);
            Storyboard.SetTargetName(MessageAnimationX, Message.Name);
            Storyboard.SetTargetName(MessageAnimationY, Message.Name);

            Storyboard.SetTargetProperty(MessageAnimationX, new PropertyPath(Canvas.LeftProperty));
            Storyboard.SetTargetProperty(MessageAnimationY, new PropertyPath(Canvas.TopProperty));

            this.BeginAnimation(Canvas.LeftProperty,MessageAnimationX);
            this.BeginAnimation(Canvas.TopProperty, MessageAnimationY);
            DispatcherTimer timerDel = new DispatcherTimer();
            timerDel.Tick += TimerDel_Tick;
            timerDel.Interval = TimeSpan.FromSeconds(Logic.Config.SpeedSecond);
            timerDel.Start();
        }

        private void TimerDel_Tick(object sender, EventArgs e)
        {
            Logic.w.DeleteMessage(this);
        }
    }
}
