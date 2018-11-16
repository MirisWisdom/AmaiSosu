using System.Diagnostics;

namespace Atarashii.CLI
{
    public class Assembly
    {
        /// <summary>
        ///     File information of the calling assembly.
        /// </summary>
        private static readonly FileVersionInfo Info =
            FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetEntryAssembly().Location);

        /// <summary>
        ///     Product name of the executable.
        /// </summary>
        public static string ProductName => Info.ProductName;

        /// <summary>
        ///     Company name of the executable.
        /// </summary>
        public static string CompanyName => Info.CompanyName;
    }
}