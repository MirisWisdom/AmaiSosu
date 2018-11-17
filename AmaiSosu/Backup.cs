using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AmaiSosu
{
    /// <summary>
    ///     Backs up any existing OpenSauce files in the installation directory by moving them to a dedicated
    ///     directory. The backup directory is located in the installation, and is named AmaiSosu.Backup.[GUID].
    ///     If the backup directory ends up being empty (therefore, a truly fresh OpenSauce installation), then it
    ///     will be deleted from the file system.
    /// </summary>
    public class Backup
    {
        /// <summary>
        ///     Directories created by the OpenSauce installer.
        /// </summary>
        private static readonly List<string> Directories = new List<string>
        {
            "data",
            "MaxScripts",
            "shaders",
            "tags"
        };

        /// <summary>
        ///     Files created by the OpenSauce installer.
        /// </summary>
        private static readonly List<string> Files = new List<string>
        {
            "CheApe.map",
            "CrashSender1401.exe",
            "msvcp120.dll",
            "OS_Sapien.exe",
            "CheApeDLLG.dll",
            "dbghelp.dll",
            "msvcr100.dll",
            "OS_Settings.Editor.xml",
            "CheApeDLLS.dll",
            "dinput8.dll",
            "msvcr120.dll",
            "OS_Tool.exe",
            "CheApeDLLT.dll",
            "Halo1_CE_Readme.txt",
            "OpenSauceDedi.dll",
            "vccorlib120.dll",
            "crashrpt_lang.ini",
            "Halo1_CheApe_Readme.txt",
            "OS_Guerilla.exe",
            "CrashRpt1401.dll",
            "msvcp100.dll",
            "OS_haloceded.exe"
        };

        /// <summary>
        ///     OpenSauce installation target path.
        /// </summary>
        private readonly string _path;

        public Backup(string path)
        {
            _path = path;
        }

        /// <summary>
        ///     Public wrapper for the OpenSauce data backup methods.
        /// </summary>
        public void Commit()
        {
            var backupDir = Path.Combine(_path, "AmaiSosu.Backup." + Guid.NewGuid());
            Directory.CreateDirectory(backupDir);
            MoveFilesTo(backupDir);
            MoveDirectoriesTo(backupDir);
            if (!Directory.EnumerateFileSystemEntries(backupDir).Any()) Directory.Delete(backupDir);
        }

        /// <summary>
        ///     Moves existing OpenSauce files to the designated destination.
        /// </summary>
        /// <param name="destination">
        ///    Target directory to move the files to.
        /// </param>
        private void MoveFilesTo(string destination)
        {
            foreach (var dir in Directories)
            {
                var srcPath = Path.Combine(_path, dir);
                var dstPath = Path.Combine(destination, dir);

                if (Directory.Exists(srcPath))
                    Directory.Move(srcPath, dstPath);
            }
        }

        /// <summary>
        ///     Moves existing OpenSauce directories to the designated destination.
        /// </summary>
        /// <param name="destination">
        ///    Target directory to move the directories to.
        /// </param>
        private void MoveDirectoriesTo(string destination)
        {
            foreach (var file in Files)
            {
                var srcPath = Path.Combine(_path, file);
                var dstPath = Path.Combine(destination, file);

                if (File.Exists(srcPath))
                    File.Move(srcPath, dstPath);
            }
        }
    }
}