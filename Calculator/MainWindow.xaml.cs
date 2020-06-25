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

namespace Calculator
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
            var first = Convert.ToInt32(txtFirstNumber.Text);
            var second = Convert.ToInt32(txtSecondNumber.Text);
            lblSumResult.Content = $"{first} + {second} = {first + second}";
            lblMinResult.Content = $"{first} - {second} = {first - second}";
            lblDivResult.Content = $"{first} / {second} = {first / second}";
            lblMulResult.Content = $"{first} * {second} = {first * second}";
        }
    }
}