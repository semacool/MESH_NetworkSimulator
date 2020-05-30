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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MESHNETWORK.Windows
{
    /// <summary>
    /// Логика взаимодействия для ColorPage.xaml
    /// </summary>
    public partial class ColorPage : Window
    {
        public ColorPage()
        {
            InitializeComponent();
            this.Loaded += ColorPage_Loaded;
        }

        /// <summary>
        /// Загрузка цветов из найстроек
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorPage_Loaded(object sender, RoutedEventArgs e)
        {
            BackG.Text = Classes.Logic.Config.ColorBackGround;
            KnotB.Text = Classes.Logic.Config.ColorKnot;
            KnotSl.Text = Classes.Logic.Config.ColorSelect;
            KnotS.Text = Classes.Logic.Config.ColorSource;
            KnotT.Text = Classes.Logic.Config.ColorTarget;
        }

        /// <summary>
        /// Фиксация изменений
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveBut_Click(object sender, RoutedEventArgs e)
        {
            bool Test = BackG.Background == null || KnotB.Background == null ||
                        KnotSl.Background == null ||
                        KnotSl.Background == null || KnotT.Background == null;
            if (!Test) 
            {
                if(MessageBox.Show("Вы уверены?","Подтверждение",MessageBoxButton.YesNo) == MessageBoxResult.Yes) 
                {
                    Classes.Logic.Config.ColorBackGround = BackG.Text;
                    Classes.Logic.Config.ColorKnot = KnotB.Text;
                    Classes.Logic.Config.ColorSelect = KnotSl.Text;
                    Classes.Logic.Config.ColorSource = KnotS.Text;
                    Classes.Logic.Config.ColorTarget = KnotT.Text;

                    Close();
                }
            }
            else 
            {
                MessageBox.Show("Произошла ошибка, вы ввели неправильный цвет.\n(Формат: \"#ffffffff\")");
            }         
        }
    }
}
