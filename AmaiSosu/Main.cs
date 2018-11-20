using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
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
                var backupDir = System.IO.Path.Combine(_path, "AmaiSosu.Backup." + Guid.NewGuid());
                var backup = new Backup(Path, backupDir);

                Directory.CreateDirectory(backupDir);

                backup.MoveFiles();
                backup.MoveDirectories();
                backup.MoveHac2();

                OpenSauce.Install(Path);

                MoveOpenSauceIde();
                RestoreShaders(backupDir);
                CleanUpBackupDir(backupDir);

                InstallText = "Installation has been successful!";
            }
            catch (Exception e)
            {
                InstallText = e.Message;
            }
        }

        /// <summary>
        ///     Restores the shader files from the backed up shaders directory.
        /// </summary>
        /// <param name="backupDir">
        ///    Directory where the backed up shaders directory is present. 
        /// </param>
        private void RestoreShaders(string backupDir)
        {
            const string shadersDir = "shaders";

            var shaders = new List<string>
            {
                "EffectCollection_ps_1_1.enc",
                "EffectCollection_ps_1_4.enc",
                "EffectCollection_ps_2_0.enc",
                "vsh.enc"
            };

            foreach (var shader in shaders)
            {
                var source = System.IO.Path.Combine(backupDir, shadersDir, shader);
                var target = System.IO.Path.Combine(Path, shadersDir, shader);

                if (File.Exists(source))
                    File.Move(source, target);
            }
        }

        /// <summary>
        ///     Removes any empty directories in the backup directory.
        /// </summary>
        /// <param name="backupDir">
        ///    Backup directory to check for empty directories.
        /// </param>
        private void CleanUpBackupDir(string backupDir)
        {
            if (!Directory.EnumerateFileSystemEntries(backupDir).Any()) Directory.Delete(backupDir);
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