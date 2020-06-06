using MESHNETWORK.Classes;
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
    /// Логика взаимодействия для AutorizationPage.xaml
    /// </summary>
    public partial class AutorizationPage : Window
    {
        public AutorizationPage()
        {
            InitializeComponent();
            this.Loaded += AutorizationPage_Loaded;
        }

        private void AutorizationPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (Logic.Config.Login != "") LoginBox.Text = Logic.Config.Login;
            if (Logic.Config.Password != "") PassBox.Password = Logic.Config.Password;
        }

        private void AuthBut_Click(object sender, RoutedEventArgs e)
        {
            string Login = LoginBox.Text;
            string Password = PassBox.Password;
            
            if (Logic.Server.Authorization(Login,Password)) 
            {
                if (SaveConfig.IsChecked.Value) 
                {
                    Logic.Config.SaveAutorization(Login,Password);
                }
                new ServerWindow().ShowDialog();
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль!");
            }
        }
    }
}
