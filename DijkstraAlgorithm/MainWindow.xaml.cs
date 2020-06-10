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
            gamePanel.Rows = 10;
            gamePanel.Columns = 20;
            for (int i = 0; i < gamePanel.Rows; i++)
            {
                for(int j = 0; j < gamePanel.Columns; j++)
                {
                    Button b = new Button();
                    Thickness margin = b.Margin;
                    margin.Left = 2;
                    margin.Bottom = 2;
                    b.Margin = margin;
                    b.Content = $"{i} {j}";
                    b.Width = 50;
                    b.Height = 50;
                    b.Click += ChangeColor;
                    gamePanel.Children.Add(b);
                }

            }
        }

        public bool isStartPoint = false;
        public bool isEndPoint = false;
        public bool isWalls = false;
        public string starterCoords;
        public string endCoords;

        private void ChangeColor(object sender, RoutedEventArgs e)
        {   
            if (isStartPoint == true)
            {
                ((Button)sender).Background = Brushes.Orange;
                starterCoords = (string)((Button)sender).Content;
                isStartPoint = false;
            }
            else if (isEndPoint == true)
            {
                ((Button)sender).Background = Brushes.DodgerBlue;
                endCoords = (string)((Button)sender).Content;
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
