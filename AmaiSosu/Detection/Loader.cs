namespace AmaiSosu.Detection
{
    /// <summary>
    ///     Static API for the Atarashii Loader Module.
    /// </summary>
    public static class Loader
    {
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