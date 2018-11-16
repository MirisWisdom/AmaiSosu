using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AmaiSosu.GUI.Annotations;

namespace AmaiSosu.GUI
{
    /// <summary>
    ///     Main AmaiSosu model.
    /// </summary>
    public class Main : INotifyPropertyChanged
    {
        /// <summary>
        /// Installation path.
        /// Path is expected to contain the HCE executable.
        /// </summary>
        private string _path;
        
        /// <summary>
        /// Installation is possible given the current state.
        /// </summary>
        private bool _canInstall;
        
        /// <summary>
        /// Installation path.
        /// </summary>
        public string Path
        {
            get => _path;
            set
            {
                if (value == _path) return;
                _path = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Installation is possible given the current state.
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
        /// Invokes the installation procedure.
        /// </summary>
        public void Install()
        {
            throw new NotImplementedException();
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}