using System;
using System.Collections.Generic;
using System.IO;
using Atarashii.Common;

namespace Atarashii.Modules.OpenSauce
{
    public class InstallerFactory
    {
        /// <summary>
        ///     Available OpenSauce Installer types.
        /// </summary>
        public enum Type
        {
            Default
        }

        private readonly string _installationPath;
        private readonly Output _output;

        /// <summary>
        ///     OpenSauceInstallerFactory constructor.
        /// </summary>
        /// <param name="installationPath">
        ///     The HCE directory path -- used to install the OpenSauce library data to.
        /// </param>
        public InstallerFactory(string installationPath)
        {
            _installationPath = installationPath;
        }

        /// <inheritdoc />
        /// <param name="installationPath">
        ///     The HCE directory path -- used to install the OpenSauce library data to.
        /// </param>
        /// <param name="output">
        ///     Output class for  packages to write messages to.
        /// </param>
        public InstallerFactory(string installationPath, Output output) : this(installationPath)
        {
            _output = output;
        }

        /// <summary>
        ///     Retrieves OpenSauceInstaller instance.
        /// </summary>
        /// <param name="type">
        ///     Type of OpenSauceInstaller instance.
        /// </param>
        /// <returns>
        ///     OpenSauceInstaller instance for installing OpenSauce to the filesystem with the built-in packages.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Invalid OpenSauceInstaller type given.
        /// </exception>
        public Installer Get(Type type = Type.Default)
        {
            switch (type)
            {
                case Type.Default:
                    return new Installer(_installationPath, GetOpenSaucePackages(), _output);
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        /// <summary>
        ///     Retrieve a list of packages that represent the OpenSauce installation data.
        /// </summary>
        /// <returns>
        ///     A list of OpenSauce packages that replicate an original OS installation when installed.
        ///     All of the packages are expected to be in the directory defined by the Package.Directory constant.
        /// </returns>
        private List<Package> GetOpenSaucePackages()
        {
            var guiDirPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            var usrDirPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            var libPackage = Path.Combine(Package.Directory, $"{Installer.LibPackage}.{Package.Extension}");
            var guiPackage = Path.Combine(Package.Directory, $"{Installer.GuiPackage}.{Package.Extension}");
            var usrPackage = Path.Combine(Package.Directory, $"{Installer.UsrPackage}.{Package.Extension}");

            return new List<Package>
            {
                new Package(libPackage, "OpenSauce core and dependencies", _installationPath, _output),
                new Package(guiPackage, "In-game OpenSauce UI assets", guiDirPath, _output),
                new Package(usrPackage, "OpenSauce XML user configuration", usrDirPath, _output)
            };
        }
    }
}