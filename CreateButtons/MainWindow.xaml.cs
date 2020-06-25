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

namespace CreateButtons
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            canvas1.Children.Clear();

            var x = 20;
            var y = 20;

            for (var i = 0; i < x; i++)
            {
                for (var j = 0; j < y; j++)
                {
                    var button = new Button()
                    {
                        Width = 50,
                        Height = 50,
                    };

                    Canvas.SetTop(button, j * 50);
                    Canvas.SetLeft(button, i * 50);

                    canvas1.Children.Add(button);
                }
            }
        }
    }
}