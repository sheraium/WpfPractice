using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TodoList
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

        private void AddToListBox(string item)
        {
            listboxTasks.Items.Add(item);
            txtInput.Text = "";
            btnAdd.IsEnabled = false;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddToListBox(txtInput.Text);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            listboxTasks.Items.Remove(listboxTasks.SelectedItem);
            btnDelete.IsEnabled = false;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnDelete.IsEnabled = true;
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtInput.Text.Length == 0)
            {
                btnAdd.IsEnabled = false;
            }

            btnAdd.IsEnabled = true;
            if (e.Key == Key.Enter)
            {
                AddToListBox(txtInput.Text);
            }
        }
    }
}