using System;
using System.Collections.Generic;
using System.IO;

namespace AmaiSosu.IO
{
    /// <summary>
    ///     Returns Move instances built using the inbound arguments. This factory is designed for backing up or
    ///     restoring data based on the provided Type value.
    /// </summary>
    public static class MoveFactory
    {
        /// <summary>
        ///     Type of move responsibility that the Move instance should hold.
        /// </summary>
        public enum Type
        {
            /// <summary>
            ///     Move-type instance which deals with backing up OpenSauce files.
            /// </summary>
            BackupOsFiles,

            /// <summary>
            ///     Move-type instance which deals with backing up OpenSauce directories.
            /// </summary>
            BackupOsDirectories,

            /// <summary>
            ///     Move-type instance which deals with backing up HAC2 files.
            /// </summary>
            BackupHac2Files,

            /// <summary>
            ///     Move-type instance which deals with restoring HCE shaders.
            /// </summary>
            RestoreHceShaders
        }

        /// <summary>
        ///     Returns Move instances built using the inbound arguments. The returned Move instances will deal with
        ///     either backing up or restoring data based on the chosen type.
        /// </summary>
        /// <param name="type">
        ///     <see cref="Type" />
        /// </param>
        /// <param name="sourceDirectory">
        ///     The directory where the data could resides in.
        /// </param>
        /// <param name="targetDirectory">
        ///     The directory where the files should be moved to.
        /// </param>
        /// <returns>
        ///     Move-type instance with the inbound arguments.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Given Type value is invalid.
        /// </exception>
        public static Move Get(Type type, string sourceDirectory, string targetDirectory)
        {
            switch (type)
            {
                case Type.BackupOsFiles:
                    return new MoveFile(new List<string>
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
                    }, sourceDirectory, targetDirectory);
                case Type.BackupOsDirectories:
                    return new MoveDirectory(new List<string>
                    {
                        "data",
                        "MaxScripts",
                        "shaders",
                        "tags",
                        "OpenSauceIDE"
                    }, sourceDirectory, targetDirectory);
                case Type.BackupHac2Files:
                    return new MoveFile(new List<string>
                    {
                        "loader.dll"
                    }, Path.Combine(sourceDirectory, "controls"), targetDirectory);
                case Type.RestoreHceShaders:
                    return new MoveFile(new List<string>
                    {
                        "EffectCollection_ps_1_1.enc",
                        "EffectCollection_ps_1_4.enc",
                        "EffectCollection_ps_2_0.enc",
                        "vsh.enc"
                    }, Path.Combine(targetDirectory, "shaders"), Path.Combine(sourceDirectory, "shaders"));
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}