﻿using MESHNETWORK.Classes;
using MESHNETWORK.MyControls;
using MESHNETWORK.Windows;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MESHNETWORK
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SaveFileDialog SFD;
        OpenFileDialog OFD;

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
           
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Can.DataContext = Logic.Config.ColorBackGround;
            Logic.w = this;
        }

        #region Удаление и добавление узлов
        private void AddPoint_Click(object sender, RoutedEventArgs e)
        {
            Logic.Objects.Knots.Add(new KnotSave(Mouse.GetPosition(Can)));
            Can.Children.Add(new KnotVisual(Logic.Objects.Knots.Last()));
        }

        private void DeletePoint_Click(object sender, RoutedEventArgs e)
        {
            Logic.Objects.Knots.Remove(Logic.SelectVisualKnot.ks);
            Can.Children.Remove(Logic.SelectVisualKnot);
        }
        #endregion

        #region Взаимодействие с меню
        private void ColorConfig_Click(object sender, RoutedEventArgs e)
        {
            new ColorPage().ShowDialog();
            Can.DataContext = Logic.Config.ColorBackGround;
        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            SFD = new SaveFileDialog();
            SFD.FileName = "Графы.json";
            SFD.ShowDialog();
            Logic.Json.SaveFile(Logic.Objects.Knots, SFD.FileName);
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OFD = new OpenFileDialog();
            OFD.Filter = "json files (*.json)|*.json";
            OFD.ShowDialog();
            if (OFD.FileName.EndsWith(".json")) 
            {
                Logic.UpdateData();
                Can.Children.Clear();
                Logic.Json.OpenFile(OFD.FileName);
                CreateCanvas();
            }      
        }

        private void ClearCanvas_Click(object sender, RoutedEventArgs e)
        {
            Logic.UpdateData();
            Can.Children.Clear();
        }
        #endregion

        /// <summary>
        /// Создание элементов на поле
        /// </summary>
        private void CreateCanvas() 
        {
            foreach(KnotSave knot in Logic.Objects.Knots) 
            {
                Can.Children.Add(new KnotVisual(knot));
            }
        }

        private void SendServer_Click(object sender, RoutedEventArgs e)
        {
            new AutorizationPage().ShowDialog();
        }
    }
}
