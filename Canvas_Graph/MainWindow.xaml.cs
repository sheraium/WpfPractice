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

namespace Canvas_Graph
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static double x = 0;
        public static double y = 0;
        public static double originX = 0;
        public static double originY = 0;
        public static bool initialized = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void DrawLine(double x, double y, double x2, double y2)
        {
            var ln = new Line();
            ln.X1 = x;
            ln.Y1 = y;
            ln.X2 = x2;
            ln.Y2 = y2;
            ln.StrokeThickness = 3;
            ln.Stroke = Brushes.White;
            cnv.Children.Add(ln);
        }

        private void AddLabel(double x, double y, string content)
        {
            var lb = new Label();
            lb.Content = content;
            lb.Margin = new Thickness(x, y, this.Width - x - 50, this.Height - y - 100);
            lb.Foreground = Brushes.White;
            lb.FontSize = 10;
            grd.Children.Add(lb);
        }

        private void Cnv_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (initialized)
            {
                var tempX = e.GetPosition(cnv).X;
                var tempY = e.GetPosition(cnv).Y;
                DrawLine(x, y, tempX, tempY);
                DrawLine(originX, y, originX, tempY);
                var temp = tempX - originX;
                DrawLine(x, originY, tempX, originY);
                AddLabel(tempX, originY + 10, temp.ToString());
                temp = cnv.Width - tempY - originY;
                AddLabel(originX - 50, tempY, temp.ToString());
                x = tempX;
                y = tempY;
            }
            else
            {
                initialized = true;
                x = e.GetPosition(cnv).X;
                y = e.GetPosition(cnv).Y;
                originX = x;
                originY = y;
            }
        }
    }
}