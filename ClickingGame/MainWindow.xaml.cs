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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ClickingGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int score = 0;
        public static int time = 10;
        public static Random rnd = new Random();
        public static DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            timer.Tick += TimerOnTick;
            timer.Interval = TimeSpan.FromSeconds(1);
        }

        private void TimerOnTick(object sender, EventArgs e)
        {
            time--;
            txtTime.Text = "Time: " + time;
            if (time == 0)
            {
                timer.Stop();
                cnvGame.Children.Clear();
            }
        }

        private void AddRectangle()
        {
            var temp = new Rectangle();
            temp.Width = 50;
            temp.Height = 50;
            temp.Fill = Brushes.Black;
            var x = rnd.Next() % (cnvGame.Width - 50);
            var y = rnd.Next() % (cnvGame.Height - 50);
            temp.Margin = new Thickness(x, y, 0, 0);
            temp.MouseDown += RectangleOnMouseDown;
            cnvGame.Children.Add(temp);
        }

        private void RectangleOnMouseDown(object sender, MouseButtonEventArgs e)
        {
            cnvGame.Children.Remove((Rectangle)sender);
            score++;
            txtScore.Text = "Score = " + score;
            AddRectangle();
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            timer.Start();
            score = 0;
            time = 10;
            AddRectangle();
        }
    }
}