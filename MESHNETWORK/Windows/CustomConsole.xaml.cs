using MESHNETWORK.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MESHNETWORK.Windows
{
    /// <summary>
    /// Логика взаимодействия для CustomConsole.xaml
    /// </summary>
    public partial class CustomConsole : Window
    {
        uint Id;

        RouterKnot RKnot => Logic.Router.Knots.Find(ks => ks.Knot.id == Id);
      
        public CustomConsole(uint Id)
        {
            InitializeComponent();

            this.Id = Id;
            this.Loaded += CustomConsole_Loaded;
        }

        private void CustomConsole_Loaded(object sender, RoutedEventArgs e)
        {
            Title =$"{RKnot.Knot.id} ({RKnot.Knot.Name}) - Console";
            ListAnswers.ItemsSource = RKnot.MesConsole;
        }

        public void RefreshItems() 
        {
            ListAnswers.ItemsSource = RKnot.MesConsole;
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            Message Message;
            ///Добавление сообщения в консоль
            string TextM = InputText.Text;
            RKnot.MesConsole.Add(new ConsoleMessage(InputText.Text, RKnot.Knot.id, RKnot.Knot.id));
            RefreshItems();

            ///Узнаём тип сообщения
            string type = TextM.Substring(0, TextM.IndexOf(' '));

            ///Создаём сообщение
            switch (type) 
            {
                case "send":
                Message = new SendMessage(TextM, RKnot.Knot.id, uint.Parse(TextM.Split(' ')[1]));
                    break;
                case "ping":
                Message = new PingMessage(RKnot.Knot.id, uint.Parse(TextM.Split(' ')[1]));
                    break;
                default:
                Message = new ConsoleMessage("Error:\tBad Command", RKnot.Knot.id, RKnot.Knot.id);
                    break;
            }

            ///Добовляем в отправку
            RKnot.MesOut.Push(Message);
            RKnot.LastsIdMessage.Add(Message.Id);
        }
    }
}
