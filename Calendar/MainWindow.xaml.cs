using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

namespace Calendar
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

        private void cldDate_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                listBoxEvents.Items.Add(cldDate.SelectedDate.ToString());
                using (var sr = new StreamReader(cldDate.SelectedDate.ToString()))
                {
                    while (!sr.EndOfStream)
                    {
                        listBoxEvents.Items.Add(sr.ReadLine());
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void listBoxEvents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnDelete.IsEnabled = true;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var item = txtTime.Text + " : " + txtName.Text;
            listBoxEvents.Items.Add(item);
            SaveEvents();
        }

        private void SaveEvents()
        {
            try
            {
                listBoxEvents.Items.Add(cldDate.SelectedDate.ToString());
                using (var sw = new StreamWriter(cldDate.SelectedDate.ToString()))
                {
                    foreach (var item in listBoxEvents.Items)
                    {
                        sw.WriteLine(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            btnDelete.IsEnabled = false;
            listBoxEvents.Items.Remove(listBoxEvents.SelectedItems);
        }
    }
}