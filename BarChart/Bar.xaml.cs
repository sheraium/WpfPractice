using BarChart.Annotations;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BarChart
{
    /// <summary>
    /// Interaction logic for BarChart.xaml
    /// </summary>
    public partial class Bar : UserControl, INotifyPropertyChanged
    {
        private double _value;

        public double Value
        {
            get { return _value; }
            set
            {
                _value = value;
                UpdateBarHeight();
                NotifyPropertyChanged("Value");
            }
        }

        private double _maxValue;

        public double MaxValue
        {
            get => _maxValue;
            set
            {
                _maxValue = value;
                UpdateBarHeight();
                NotifyPropertyChanged("MaxValue");
            }
        }

        private double _barHeight;

        public double BarHeight
        {
            get => _barHeight;
            set
            {
                _barHeight = value;
                NotifyPropertyChanged("BarHeight");
            }
        }

        private Brush _color;

        public Brush Color
        {
            get => _color;
            set
            {
                _color = value;
                NotifyPropertyChanged("Color");
            }
        }

        private void UpdateBarHeight()
        {
            if (_maxValue > 0)
            {
                var percent = (_value * 100) / _maxValue;
                BarHeight = (percent * this.ActualHeight) / 100;
            }
        }

        public Bar()
        {
            InitializeComponent();
            DataContext = this;
            Color = Brushes.Black;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateBarHeight();
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateBarHeight();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}