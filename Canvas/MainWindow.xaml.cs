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

namespace Canvas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _draw;
        private double _x = 0;
        private double _y = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Cnv_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _draw = true;
            _x = e.GetPosition(cnv).X;
            _y = e.GetPosition(cnv).Y;
        }

        private void Cnv_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (_draw && e.LeftButton == MouseButtonState.Pressed)
            {
                cnv.Children.Clear();
                //var line = new Line();
                //line.X1 = _x;
                //line.Y1 = _y;
                //line.X2 = e.GetPosition(cnv).X;
                //line.Y2 = e.GetPosition(cnv).Y;
                //line.StrokeThickness = 2;
                //line.Stroke = Brushes.Brown;
                //cnv.Children.Add(line);

                var rectangle = new Rectangle();
                var height = e.GetPosition(cnv).Y - _y;
                var width = e.GetPosition(cnv).X - _x;
                rectangle.Height = Math.Abs(height);
                rectangle.Width = Math.Abs(width);
                rectangle.StrokeThickness = 2;
                rectangle.Stroke = Brushes.Brown;
                var top = _y;
                var left = _x;
                if (height < 0)
                {
                    top = e.GetPosition(cnv).Y;
                }
                if (width < 0)
                {
                    left = e.GetPosition(cnv).X;
                }
                System.Windows.Controls.Canvas.SetTop(rectangle, top);
                System.Windows.Controls.Canvas.SetLeft(rectangle, left);
                cnv.Children.Add(rectangle);
            }
        }

        private void Cnv_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _draw = false;
        }
    }
}