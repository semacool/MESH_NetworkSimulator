using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MESHNETWORK.Classes
{
    /// <summary>
    /// Класс Узла
    /// </summary>
    public class KnotSave : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public static uint NextId = 0;

        public uint id { get; private set; }

        double xCord;
        public double CordX
        {
            get { return xCord; }
            set
            {
                xCord = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.CordX)));
            }
        }

        double yCord;
        public double CordY
        {
            get { return yCord; }
            set
            {
                yCord = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.CordY)));
            }
        }

        double radius;
        public double Radius
        {
            get { return radius; }
            set
            {
                radius = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Radius)));
            }
        }

        string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Name)));
            }
        }

        public TypeNode typeNode;

        /// <summary>
        /// Создание по клику
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="XCord"></param>
        /// <param name="YCord"></param>
        /// <param name="Radius"></param>
        /// <param name="Source"></param>
        /// <param name="Target"></param>
        public KnotSave(Point point)
        {
            id = NextId++;
            CordX = point.X;
            CordY = point.Y;
            radius = 100;
            typeNode = TypeNode.common;
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
        public KnotSave(uint Id, string Name, double XCord, double YCord, double Radius, TypeNode TypeNode = TypeNode.common)
        {
            NextId++;
            this.id = Id;
            this.CordX = XCord;
            this.CordY = YCord;
            this.Radius = Radius;
            this.Name = Name;
            this.typeNode = TypeNode;
        }
        public KnotSave()
        {
        }
    }
    public enum TypeNode {common, source, target}
}
