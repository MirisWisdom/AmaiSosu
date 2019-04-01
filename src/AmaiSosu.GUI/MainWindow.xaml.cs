/**
 * Copyright (C) 2018-2019 Emilian Roman
 * 
 * This file is part of HCE.AmaiSosu.
 * 
 * HCE.AmaiSosu is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * HCE.AmaiSosu is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with HCE.AmaiSosu.  If not, see <http://www.gnu.org/licenses/>.
 */

using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;

namespace AmaiSosu.GUI
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
            InstallButton.IsEnabled = false;
            InstallButton.Content   = "...";
            
            Task.Run(() => { _main.Install(); }).GetAwaiter().GetResult();

            InstallButton.IsEnabled = true;
            InstallButton.Content   = "⬛ Install OpenSauce";
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
            Process.Start("https://github.com/yumiris/HCE.AmaiSosu");
        }

        private void Releases(object sender, RoutedEventArgs e)
        {
            Process.Start("https://github.com/yumiris/HCE.AmaiSosu/releases");
        }

        private void Version(object sender, RoutedEventArgs e)
        {
            Process.Start($"https://github.com/yumiris/HCE.AmaiSosu/releases/{_main.Version}");
        }
    }
}