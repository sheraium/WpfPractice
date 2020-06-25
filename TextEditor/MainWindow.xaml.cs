using System;
using System.Collections.Generic;
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
using Microsoft.Win32;

namespace TextEditor
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

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            var fd = new OpenFileDialog();
            if (fd.ShowDialog() == true)
            {
                using (var reader = new StreamReader(fd.FileName))
                {
                    txtBox.Document.Blocks.Clear();
                    txtBox.AppendText(reader.ReadToEnd());
                }
            }
        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            var sf = new SaveFileDialog();
            if (sf.ShowDialog() == true)
            {
                using (var writer = new StreamWriter(sf.FileName))
                {
                    var text = new TextRange(txtBox.Document.ContentStart, txtBox.Document.ContentEnd).Text;
                    writer.Write(text);
                }
            }
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}