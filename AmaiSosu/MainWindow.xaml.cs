using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace AmaiSosu
{
    public partial class MainWindow : Window
    {
        private readonly Main _main;

        public MainWindow()
        {
            InitializeComponent();
            _main = (Main) DataContext;
            _main.Initialise();
        }

        private void Install(object sender, RoutedEventArgs e)
        {
            _main.Install();
        }

        private void Browse(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "HCE Executable|haloce.exe"
            };
            
            if (openFileDialog.ShowDialog() == true)
                _main.Path = Path.GetDirectoryName(openFileDialog.FileName);
        }

        private void About(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/yumiris/HCE.AmaiSosu");
        }

        private void Releases(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/yumiris/HCE.AmaiSosu/releases");
        }
    }
}