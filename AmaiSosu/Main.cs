using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using AmaiSosu.Properties;
using Atarashii.API;

namespace AmaiSosu
{
    /// <summary>
    ///     Main AmaiSosu model.
    /// </summary>
    public class Main : INotifyPropertyChanged
    {
        /// <summary>
        ///     Installation is possible given the current state.
        /// </summary>
        private bool _canInstall = true;

        /// <summary>
        ///     Current state of the OpenSauce installation.
        /// </summary>
        private string _installState = "Currently awaiting the end-user to invoke OpenSauce installation.";

        /// <summary>
        ///     Installation path.
        ///     Path is expected to contain the HCE executable.
        /// </summary>
        private string _path;

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
                InstallText = "Click Browse and select the HCE installation path.";
            }
        }

        /// <summary>
        ///     Invokes the installation procedure.
        /// </summary>
        public void Install()
        {
            try
            {
                new Backup(Path).Commit();
                OpenSauce.Install(Path);
                MoveOpenSauceIde();
                InstallText = "Installation has been successful!";
            }
            catch (Exception e)
            {
                InstallText = e.Message;
            }
        }

        /// <summary>
        ///     Moves the OpenSauce IDE directory to the HCE directory for convenience.
        ///     This method calls the static Copy.All(DirectoryInfo source, DirectoryInfo target) method.
        /// </summary>
        private void MoveOpenSauceIde()
        {
            const string dirName = "OpenSauceIDE";
            
            var source =
                System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                    "Kornner Studios", "OpenSauce", dirName);

            var target = System.IO.Path.Combine(Path, dirName);
            
            Copy.All(new DirectoryInfo(source), new DirectoryInfo(target));
            Directory.Delete(source, true);
        }

        /// <summary>
        ///     Updates the install text upon successful path provision.
        /// </summary>
        private void OnPathChanged()
        {
            if (Directory.Exists(Path))
                InstallText = "Ready to install OpenSauce to the HCE folder!";
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}