using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using AmaiSosu.IO;
using AmaiSosu.Properties;
using Atarashii.API;
using static AmaiSosu.Resources.FileNames;
using static AmaiSosu.Resources.Messages;

namespace AmaiSosu
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
        private string _installState = BrowseHce;

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
                    .GetManifestResourceStream(AmaiSosuVersion))
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
                InstallText = BrowseHce;
            }
        }

        /// <summary>
        ///     Invokes the installation procedure.
        /// </summary>
        public void Install()
        {
            try
            {
                var backupDir = System.IO.Path.Combine(_path, AmaiSosuBackup + '.' + Guid.NewGuid());

                CommitBackups(backupDir);
                OpenSauce.Install(Path);
                FinishInstall(backupDir);

                InstallText = InstallSuccess;
            }
            catch (Exception e)
            {
                InstallText = e.Message;
            }
        }

        /// <summary>
        ///     Conducts the OpenSauce & HAC2 data backup routines.
        /// </summary>
        /// <param name="backupDir">
        ///     Backup directory to use for backing up OpenSauce & HAC2 data.
        /// </param>
        private void CommitBackups(string backupDir)
        {
            Directory.CreateDirectory(backupDir);

            new List<Move>
            {
                MoveFactory.Get(MoveFactory.Type.BackupOsFiles, _path, backupDir),
                MoveFactory.Get(MoveFactory.Type.BackupOsDirectories, _path, backupDir),
                MoveFactory.Get(MoveFactory.Type.BackupHac2Files, _path, backupDir)
            }.ForEach(move => move.Commit());
        }

        /// <summary>
        ///     Conducts optional installation finalisation routines.
        ///     - Restore the HCE shaders.
        ///     - Move the OpenSauce IDE.
        ///     - Backup directory cleanup.
        /// </summary>
        /// <param name="backupDir"></param>
        private void FinishInstall(string backupDir)
        {
            // restore backed up HCE shaders
            MoveFactory.Get(MoveFactory.Type.RestoreHceShaders, _path, backupDir).Commit();

            var source =
                System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                    OpenSauceDeveloper, OpenSauceDirectory, OpenSauceIDE);

            var target = System.IO.Path.Combine(Path, OpenSauceIDE);

            Copy.All(new DirectoryInfo(source), new DirectoryInfo(target));
            Directory.Delete(source, true);

            // cleans up backup directory
            if (!Directory.EnumerateFileSystemEntries(backupDir).Any()) Directory.Delete(backupDir);
        }

        /// <summary>
        ///     Updates the install text upon successful path provision.
        /// </summary>
        private void OnPathChanged()
        {
            CanInstall = Directory.Exists(Path) && File.Exists(System.IO.Path.Combine(Path, HceExecutable));
            InstallText = CanInstall
                ? InstallReady
                : BrowseHce;
        }

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}