using System;
using System.IO;

namespace AmaiSosu.GUI.IO
{
    /// <summary>
    ///     Copy a directory and its contents. Adapted from the MSDN CopyAll method.
    ///     <see cref="!:https://docs.microsoft.com/en-us/dotnet/api/system.io.directoryinfo" />
    /// </summary>
    public static class Copy
    {
        public static void All(DirectoryInfo source, DirectoryInfo target)
        {
            if (string.Equals(source.FullName, target.FullName, StringComparison.CurrentCultureIgnoreCase)) return;

            // Check if the target directory exists, if not, create it.
            if (Directory.Exists(target.FullName) == false) Directory.CreateDirectory(target.FullName);

            // Copy each file into it's new directory.
            foreach (var fi in source.GetFiles())
            {
                Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                fi.CopyTo(Path.Combine(target.ToString(), fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (var diSourceSubDir in source.GetDirectories())
            {
                var nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);
                All(diSourceSubDir, nextTargetSubDir);
            }
        }
    }
}