using System.Windows;

namespace AmaiSosu
{
    public partial class MainWindow : Window
    {
        private readonly Main _main;

        public MainWindow()
        {
            InitializeComponent();
            _main = (Main) DataContext;
        }

        private void Install(object sender, RoutedEventArgs e)
        {
            _main.Install();
        }
    }
}