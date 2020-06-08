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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DijkstraAlgorithm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public bool isStartPoint = false;
        public bool isEndPoint = false;
        public bool isWalls = false;
        public string coords;

        private void ChangeColor(object sender, RoutedEventArgs e)
        {   
            if (isStartPoint == true)
            {
                ((Button)sender).Background = Brushes.Orange;
                coords = (string)((Button)sender).Content;
                isStartPoint = false;
            }
            else if (isEndPoint == true)
            {
                ((Button)sender).Background = Brushes.DodgerBlue;
                isEndPoint = false;
            }
            else if (isWalls == true)
            {
                ((Button)sender).Background = Brushes.DarkGray;
            }
        }

        private void StartPoint_Click(object sender, RoutedEventArgs e)
        {
            isStartPoint = true;
            isEndPoint = false;
            isWalls = false;
    }

        private void EndPoint_Click(object sender, RoutedEventArgs e)
        {
            isStartPoint = false;
            isEndPoint = true;
            isWalls = false;
        }

        private void Walls_Click(object sender, RoutedEventArgs e)
        {
            isStartPoint = false;
            isEndPoint = false;
            isWalls = true;
        }

        private void StartDijkstra_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
