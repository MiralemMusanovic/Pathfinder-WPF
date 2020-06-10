using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace DijkstraAlgorithm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool startPointBtn = false;
        public bool endPointBtn = false;
        public bool wallsBtn = false;
        public int starterRow;
        public int starterCol;
        public int finishRow;
        public int finishCol;
        public MainWindow()
        {
            InitializeComponent();
            makeGrid();
        }

        private void makeGrid()
        {
            gamePanel.Rows = 10;
            gamePanel.Columns = 20;
            for (int i = 0; i < gamePanel.Rows; i++)
            {
                for (int j = 0; j < gamePanel.Columns; j++)
                {
                    Button b = new Button();
                    Thickness margin = b.Margin;
                    margin.Left = 2;
                    margin.Bottom = 2;
                    b.Margin = margin;
                    b.Width = 50;
                    b.Height = 50;
                    b.Click += ChangeColor;
                    gamePanel.Children.Add(b);
                }
            }
        }

        private void ChangeColor(object sender, RoutedEventArgs e)
        {   
            if (startPointBtn == true)
            {
                
                    Button clicked = (Button)sender;
                    clicked.Background = Brushes.Orange;
                    starterRow = (int)clicked.GetValue(Grid.RowProperty);
                    starterCol = (int)clicked.GetValue(Grid.ColumnProperty);
                    startPointBtn = false;
            }
            else if (endPointBtn == true)
            {
                
                Button clicked = (Button)sender;
                clicked.Background = Brushes.DodgerBlue;
                finishRow = (int)clicked.GetValue(Grid.RowProperty);
                finishCol = (int)clicked.GetValue(Grid.ColumnProperty);
                endPointBtn = false;
            }
            else if (wallsBtn == true)
            {
                Button clicked = (Button)sender;
                clicked.Background = Brushes.DarkGray;
            }
        }

        private void StartPoint_Click(object sender, RoutedEventArgs e)
        {
            startPointBtn = true;
            endPointBtn = false;
            wallsBtn = false;
    }

        private void EndPoint_Click(object sender, RoutedEventArgs e)
        {
            startPointBtn = false;
            endPointBtn = true;
            wallsBtn = false;
        }

        private void Walls_Click(object sender, RoutedEventArgs e)
        {
            startPointBtn = false;
            endPointBtn = false;
            wallsBtn = true;
        }

        private void StartDijkstra_Click(object sender, RoutedEventArgs e)
        {
            startPointBtn = false;
            endPointBtn = false;
            wallsBtn = false;


            gamePanel.Children.Cast<Button>().First(e => Grid.GetRow(e) == 1 && Grid.GetColumn(e) == 1).Background = Brushes.Black;
        }
    }
}
