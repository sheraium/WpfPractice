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

namespace AddvancedCalculator
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

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                txtInput.Text = txtInput.Text + button.Content;
            }
        }

        private void Compute_Click(object sender, RoutedEventArgs e)
        {
            var input = txtInput.Text;
            var number = 0;
            var firstNumber = 0;
            var operation = ' ';
            for (int i = 0; i < input.Length; i++)
            {
                if ('0' <= input[i] && input[i] <= '9')
                {
                    number = number * 10 + (input[i] - '0');
                }
                else if (input[i] == '+'
                         || input[i] == '-'
                         || input[i] == '/'
                         || input[i] == '*')
                {
                    switch (operation)
                    {
                        case '+':
                            number = firstNumber + number;
                            break;

                        case '-':
                            number = firstNumber - number;
                            break;

                        case '/':
                            number = firstNumber / number;
                            break;

                        case '*':
                            number = firstNumber * number;
                            break;
                    }
                    operation = input[i];
                    firstNumber = number;
                    number = 0;
                }
            }

            switch (operation)
            {
                case '+':
                    number = firstNumber + number;
                    break;

                case '-':
                    number = firstNumber - number;
                    break;

                case '/':
                    number = firstNumber / number;
                    break;

                case '*':
                    number = firstNumber * number;
                    break;
            }
            txtInput.Text = number.ToString();
        }
    }
}