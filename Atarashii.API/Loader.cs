using Atarashii.Modules.Loader;

namespace Atarashii.API
{
    /// <summary>
    ///     Static API for the Atarashii Loader Module.
    /// </summary>
    public static class Loader
    {
        /// <summary>
        ///     Verifies and loads the inbound HCE executable if valid.
        /// </summary>
        /// <param name="hceExecutable">
        ///     Absolute path to a valid HCE executable.
        /// </param>
        public static void Load(string hceExecutable)
        {
            new Executable(hceExecutable).Load();
        }

        /// <summary>
        ///     Attempts to detect the path of the HCE executable on the file system.
        /// </summary>
        /// <returns>
        ///     Path to the HCE executable, assuming its installation is legal.
        /// </returns>
        public static string Detect()
        {
            return ExecutableFactory.Get(ExecutableFactory.Type.Detect).Path;
        }
    }
}