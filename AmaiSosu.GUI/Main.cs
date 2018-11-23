using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using AmaiSosu.Detection;
using AmaiSosu.GUI.Properties;
using AmaiSosu.GUI.Resources;

namespace AmaiSosu.GUI
{
    /// <summary>
    ///     Main AmaiSosu model.
    /// </summary>
    public sealed class Main : INotifyPropertyChanged
    {
        /// <summary>
        ///     Installation is possible given the current state.
        /// </summary>
        private bool _canInstall;

        /// <summary>
        ///     Current state of the OpenSauce installation.
        /// </summary>
        private string _installState = Messages.BrowseHce;

        /// <summary>
        ///     Installation path.
        ///     Path is expected to contain the HCE executable.
        /// </summary>
        private string _path;

        /// <summary>
        ///     Git version.
        /// </summary>
        public string Version
        {
            get
            {
                using (var stream = Assembly.GetExecutingAssembly()
                    .GetManifestResourceStream(FileNames.AmaiSosuVersion))
                using (var reader = new StreamReader(stream ?? throw new FileNotFoundException()))
                {
                    return reader.ReadToEnd().Trim();
                }
            }
        }

        /// <summary>
        ///     Installation path.
        /// </summary>
        public string Path
        {
            get => _path;
            set
            {
                if (value == _path) return;
                _path = value;
                OnPropertyChanged();
                OnPathChanged();
            }
        }

        /// <summary>
        ///     Installation is possible given the current state.
        /// </summary>
        public bool CanInstall
        {
            get => _canInstall;
            set
            {
                if (value == _canInstall) return;
                _canInstall = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Current state of the OpenSauce installation.
        /// </summary>
        public string InstallText
        {
            get => _installState;
            set
            {
                if (value == _installState) return;
                _installState = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Initialise the HCE path detection attempt.
        /// </summary>
        public void Initialise()
        {
            try
            {
                Path = System.IO.Path.GetDirectoryName(Loader.Detect());
                OnPathChanged();
            }
            catch (Exception)
            {
                InstallText = Messages.BrowseHce;
            }
        }

        /// <summary>
        ///     Invokes the installation procedure.
        /// </summary>
        public void Install()
        {
            try
            {
                new AmaiSosu.Main(_path).Install();
                InstallText = Messages.InstallSuccess;
            }
            catch (Exception e)
            {
                InstallText = e.Message;
            }
        }

        /// <summary>
        ///     Updates the install text upon successful path provision.
        /// </summary>
        private void OnPathChanged()
        {
            CanInstall = Directory.Exists(Path) && File.Exists(System.IO.Path.Combine(Path, FileNames.HceExecutable));
            InstallText = CanInstall
                ? Messages.InstallReady
                : Messages.BrowseHce;
        }

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}