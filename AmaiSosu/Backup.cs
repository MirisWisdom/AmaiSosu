using System.Collections.Generic;
using System.IO;

namespace AmaiSosu
{
    /// <summary>
    ///     Backs up any existing OpenSauce & HAC2 files in the installation directory by moving them to a dedicated
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
            "tags",
            "OpenSauceIDE"
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

        private readonly string _backupDir;

        public Backup(string path, string backupDir)
        {
            _path = path;
            _backupDir = backupDir;
        }

        /// <summary>
        ///     Moves the HAC2 loader to the designated destination.
        /// </summary>
        public void MoveHac2()
        {
            const string hac2Dll = "loader.dll";
            const string hac2Dir = "controls";

            var source = Path.Combine(_path, hac2Dir, hac2Dll);
            var target = Path.Combine(_backupDir, hac2Dll);

            if (File.Exists(source))
                File.Move(source, target);
        }

        /// <summary>
        ///     Moves existing OpenSauce files to the specified backup directory.
        /// </summary>
        public void MoveFiles()
        {
            foreach (var file in Files)
            {
                var source = Path.Combine(_path, file);
                var target = Path.Combine(_backupDir, file);

                if (File.Exists(source))
                    File.Move(source, target);
            }
        }

        /// <summary>
        ///     Moves existing OpenSauce directories to the specified backup directory.
        /// </summary>
        public void MoveDirectories()
        {
            foreach (var dir in Directories)
            {
                var source = Path.Combine(_path, dir);
                var target = Path.Combine(_backupDir, dir);

                if (Directory.Exists(source))
                    Directory.Move(source, target);
            }
        }
    }
}