using MESHNETWORK.Classes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Логика взаимодействия для ServerWindow.xaml
    /// </summary>
    public partial class ServerWindow : Window
    {

        OpenFileDialog OFD;
        SaveFileDialog SFD;


        public ServerWindow()
        {
            InitializeComponent();

            this.Loaded += ServerWindow_Loaded;
        }

        private void ServerWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Logic.Objects.Nets = Logic.Server.ListNets();
            ListNets.ItemsSource = Logic.Objects.Nets;
            UsersList.ItemsSource = Logic.Server.ListUsers();

            OFD = new OpenFileDialog();
            SFD = new SaveFileDialog();
        }

        /// <summary>
        /// Обновление списка схем
        /// </summary>
        private void UpdateList() 
        {
            Logic.Objects.Nets = Logic.Server.ListNets();
            ListNets.ItemsSource = Logic.Objects.Nets;
            ListNets.Items.Refresh();
        }

        /// <summary>
        /// Добавление схемы на сервер
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddNet_Click(object sender, RoutedEventArgs e)
        {       
            OFD.Filter = "json files (*.json)|*.json";
            OFD.ShowDialog();
            if (OFD.FileName.EndsWith(".json"))
            {
                Logic.Json.OpenFile(OFD.FileName);
                string NameFile = OFD.SafeFileName.Replace(".json", "Net");
                Net Net = new Net(NameFile, Logic.Objects.Knots);
                if (Logic.Server.AddNet(Net)) MessageBox.Show("Схема добавлена на сервер");
                else MessageBox.Show("Произошла ошибка!");
            }
            UpdateList();
        }

        /// <summary>
        /// Удаление схемы с сервера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveNet_Click(object sender, RoutedEventArgs e)
        {   
            if(ListNets.SelectedItem == null) { MessageBox.Show("Выберите схему"); return; }
            if(MessageBox.Show("Удалить данную схема с сервера?","Предупреждение",MessageBoxButton.YesNo) == MessageBoxResult.Yes) 
            {
                if (Logic.Server.RemoveNet(ListNets.SelectedItem as Net)) 
                    MessageBox.Show("Схема удалена!");

                else MessageBox.Show("Произошла ошибка!");
                UpdateList();
            }
        }

        /// <summary>
        /// Скачивание схемы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DowlandNet_Click(object sender, RoutedEventArgs e)
        {
            if (ListNets.SelectedItem == null) { MessageBox.Show("Выберите схему"); return; }

            Logic.Objects.Knots = Logic.Server.ListNodes(ListNets.SelectedItem as Net);
            string Name = (ListNets.SelectedItem as Net).name;
            SFD.FileName = $"{Name}.json";
            SFD.ShowDialog();
            Logic.Json.SaveFile(Logic.Objects.Knots, SFD.FileName);
        }

        /// <summary>
        /// Дать пользователю Read
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShareReader_Click(object sender, RoutedEventArgs e)
        {
            if (ListNets.SelectedItem == null) { MessageBox.Show("Выберите схему"); return; }
            if (UsersList.SelectedItem == null) { MessageBox.Show("Выберите пользователя"); return; }


            string SelectName = UsersList.SelectedItem.ToString().Split(' ').First();

            if (Logic.Server.ShareNet(ListNets.SelectedItem as Net, SelectName, "read")) 
            { 
                MessageBox.Show("Пользователь получил доступ!");
                UsersList.Items.Refresh();
            }


            else MessageBox.Show("Произошла ошибка!");

        }

        /// <summary>
        /// Дать пользователю Write
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShareWriter_Click(object sender, RoutedEventArgs e)
        {

            if (ListNets.SelectedItem == null) { MessageBox.Show("Выберите схему"); return; }
            if (UsersList.SelectedItem == null) { MessageBox.Show("Выберите пользователя"); return; }

            string SelectName = UsersList.SelectedItem.ToString().Split(' ').First();

           if(Logic.Server.ShareNet(ListNets.SelectedItem as Net, SelectName, "write")) 
            {
                MessageBox.Show("Пользователь получил доступ!");
                UsersList.Items.Refresh();
            }

            else MessageBox.Show("Произошла ошибка!");

        }

        /// <summary>
        /// Убрать у пользователя доступ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Revoke_Click(object sender, RoutedEventArgs e)
        {
            if (ListNets.SelectedItem == null) { MessageBox.Show("Выберите схему"); return; }
            if (UsersList.SelectedItem == null) { MessageBox.Show("Выберите пользователя"); return; }

            string SelectName = UsersList.SelectedItem.ToString().Split(' ').First();
            if(Logic.Server.Revoke(ListNets.SelectedItem as Net, SelectName)) 
            {
                MessageBox.Show("Пользователь потерял доступ!");
                UsersList.Items.Refresh();
            }
            else MessageBox.Show("Произошла ошибка!");
        }

        /// <summary>
        /// Показать список людей с доступом
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowShares_Click(object sender, RoutedEventArgs e)
        {
            UsersList.ItemsSource = Logic.Server.ListShares(ListNets.SelectedItem as Net);
            UsersList.Items.Refresh();
        }

        /// <summary>
        /// Показать список пользователей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowAll_Click(object sender, RoutedEventArgs e)
        {
            UsersList.ItemsSource = Logic.Server.ListUsers();
            UsersList.Items.Refresh();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Logic.Server.CloseConnection();
        }
    }
}
