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
        public bool endFound = false;
        public string startCoords;
        public string endCoords;
        public MainWindow()
        {
            InitializeComponent();
            makeGrid();
        }

        private void makeGrid()
        {
            gamePanel.Rows = 10;
            gamePanel.Columns = 10;
            for (int i = 0; i < gamePanel.Rows; i++)
            {
                for (int j = 0; j < gamePanel.Columns; j++)
                {
                    Button b = new Button();
                    Thickness margin = b.Margin;
                    margin.Left = 2;
                    b.Content = $"{i}{j}";
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
                clicked.Background = Brushes.Green;
                startCoords = (string)clicked.Content;
                
                startPointBtn = false;
            }
            else if (endPointBtn == true)
            {
                
                Button clicked = (Button)sender;
                clicked.Background = Brushes.Red;
                endCoords = (string)clicked.Content;
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

            //fix
            // iterate thro all buttons, find the 4 you need if not found, go again(infinite while loop)
            //maybe Grid.RowProperty ??
            //gamePanel.Children.Cast<Button>().First(e => Grid.GetRow(e) == 1 && Grid.GetColumn(e) == 1).Background = Brushes.Black;
            //gamePanel.Children.Cast<Button>().ElementAt(34).Background = Brushes.Red;
            //gamePanel.Children.Cast<Button>().Where(e => (Grid.GetRow(e)) == 0 && (Grid.GetColumn(e)) == 0).First().Background = Brushes.Black;
            
            int startRow = int.Parse(startCoords[0].ToString());
            int startCol = int.Parse(startCoords[1].ToString());
            int[] up = new int[] { startRow - 1 , startCol };
            int[] right = new int[] { startRow, startCol+1 };
            int[] down = new int[] { startRow+1, startCol };
            int[] left = new int[] { startRow, startCol - 1 };
            int counter = 1;
            for(int i = 0; i < 3; i++)
            {
                foreach (Button b in gamePanel.Children.Cast<Button>())
                {
                    if (b.Content.Equals(string.Join("", up)))
                    {
                        if (b.Background != Brushes.Green)
                        {
                            if (b.Content.Equals(endCoords))
                                endFound = true;



                            up[0] = startRow - 1 - counter;
                            counter++;
                            b.Background = Brushes.Blue;
                        }
                    }
                    else if (b.Content.Equals(string.Join("", right)))
                    {
                        if (b.Background != Brushes.Green)
                        {
                            if (b.Content.Equals(endCoords))
                                endFound = true;
                            right[1] = startCol + 1 + counter;
                            counter++;
                            b.Background = Brushes.Blue;
                        }
                    }
                    else if (b.Content.Equals(string.Join("", down)))
                    {
                        if (b.Background != Brushes.Green)
                        {
                            if (b.Content.Equals(endCoords))
                                endFound = true;
                            down[0] = startRow + 1 + counter;
                            counter++;
                            b.Background = Brushes.Blue;
                        }
                    }
                    else if (b.Content.Equals(string.Join("", left)))
                    {
                        if (b.Background != Brushes.Green)
                        {
                            if (b.Content.Equals(endCoords))
                                endFound = true;
                            left[1] = startCol - 1 - counter;
                            counter++;
                            b.Background = Brushes.Blue;
                        }
                    }
                }
            }
        }
    }
}
