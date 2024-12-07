using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CylinderProgressDemo
{
    public partial class MainWindow : Window
    {
        Random _rnd = new Random();
        DispatcherTimer _fillTimer = null;

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindowOnLoaded;
            this.Unloaded += MainWindowOnUnloaded;
        }

        void MainWindowOnLoaded(object sender, RoutedEventArgs e)
        {
            RandomizeProgressValues();
            _fillTimer = new DispatcherTimer();
            _fillTimer.Interval = TimeSpan.FromMilliseconds(1000);
            _fillTimer.Tick += delegate { RandomizeProgressValues(); };
            _fillTimer?.Start();
        }

        void MainWindowOnUnloaded(object sender, RoutedEventArgs e) => _fillTimer?.Stop(); 

        void RandomizeProgressValues()
        {
            if (_rnd.Next(2) == 1)
                cp1.Value = _rnd.Next((int)cp1.MinValue, (int)cp1.MaxValue);
            if (_rnd.Next(2) == 1)
                cp2.Value = _rnd.Next((int)cp2.MinValue, (int)cp2.MaxValue);
            if (_rnd.Next(2) == 1)
                cp3.Value = _rnd.Next((int)cp3.MinValue, (int)cp3.MaxValue);
            if (_rnd.Next(2) == 1)
                cp4.Value = _rnd.Next((int)cp4.MinValue, (int)cp4.MaxValue);
        }
    }
}