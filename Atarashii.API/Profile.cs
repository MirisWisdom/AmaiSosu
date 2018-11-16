using System.IO;
using Atarashii.Modules.Profile;

namespace Atarashii.API
{
    /// <summary>
    ///     Static API for the Atarashii Profile Module.
    /// </summary>
    public static class Profile
    {
        /// <summary>
        ///     Retrieves a Configuration-type representation of the provided blam.sav binary.
        /// </summary>
        /// <param name="blamPath">
        ///     Absolute path to a HCE profile blam.sav binary.
        /// </param>
        /// <returns>
        ///     Deserialised Configuration object representing the provided blam.sav binary.
        /// </returns>
        public static Configuration Parse(string blamPath)
        {
            return ConfigurationFactory.GetFromStream(File.Open(blamPath, FileMode.Open));
        }

        /// <summary>
        ///     Attempts to detect the currently used HCE profile on the filesystem.
        /// </summary>
        /// <returns>
        ///     Currently used HCE profile, assuming the environment is valid.
        /// </returns>
        public static string Detect()
        {
            return LastprofFactory.Get(LastprofFactory.Type.Detect).Parse();
        }
    }
}