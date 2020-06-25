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

namespace GuessNumber
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _lives = 10;
        private int _random = 0;

        public MainWindow()
        {
            InitializeComponent();
            Random rnd = new Random();
            _random = rnd.Next(1, 100);
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (_lives == 0)
            {
                lblFrom.Content = "You ";
                lblTo.Content = "lose";
                return;
            }

            if (e.Key == Key.Enter)
            {
                _lives--;
                var userGuressed = Convert.ToInt32(txtInput.Text);
                if (userGuressed == _random)
                {
                    lblFrom.Content = "You ";
                    lblTo.Content = "win";
                    return;
                }

                if (userGuressed < _random)
                {
                    lblFrom.Content = userGuressed;
                }
                else
                {
                    lblTo.Content = userGuressed;
                }
                lblStatus.Content = "Remaining Lives: " + _lives;

                if (_lives <= 3)
                {
                    lblStatus.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                }
            }
        }
    }
}