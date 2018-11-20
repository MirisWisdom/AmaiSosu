using System;
using System.Collections.Generic;
using System.IO;

namespace AmaiSosu.Routines
{
    /// <summary>
    ///     Returns Backup instances built using the inbound arguments.
    /// </summary>
    public class BackupFactory
    {
        /// <summary>
        ///     Type of responsibility that the Backup instance should hold.
        /// </summary>
        public enum Type
        {
            /// <summary>
            ///     Backup-type instance which deals with backing up OpenSauce files.
            /// </summary>
            OsFiles,

            /// <summary>
            ///     Backup-type instance which deals with backing up OpenSauce directories.
            /// </summary>
            OsDirectories,

            /// <summary>
            ///     Backup-type instance which deals with backing up HAC2 files.
            /// </summary>
            Hac2Files
        }

        /// <summary>
        ///     Returns Backup instances built using the inbound arguments.
        /// </summary>
        /// <param name="type">
        ///     <see cref="Type" />
        /// </param>
        /// <param name="installDirectory">
        ///     The installation directory where potential OpenSauce & HAC2 data resides in.
        /// </param>
        /// <param name="targetDirectory">
        ///     The backup directory where the files should be moved to.
        /// </param>
        /// <returns>
        ///     Backup-type instance with the inbound arguments.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Given Type value is invalid.
        /// </exception>
        public static Backup Get(Type type, string installDirectory, string targetDirectory)
        {
            switch (type)
            {
                case Type.OsFiles:
                    return new BackupFile(new List<string>
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
                    }, installDirectory, targetDirectory);
                case Type.OsDirectories:
                    return new BackupDirectory(new List<string>
                    {
                        "data",
                        "MaxScripts",
                        "shaders",
                        "tags",
                        "OpenSauceIDE"
                    }, installDirectory, targetDirectory);
                case Type.Hac2Files:
                    return new BackupFile(new List<string>
                    {
                        "loader.dll"
                    }, Path.Combine(installDirectory, "controls"), targetDirectory);
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}