using System;
using System.IO;
using Atarashii.Common;

namespace Atarashii.Modules.Profile
{
    public static class LastprofFactory
    {
        /// <summary>
        ///     Types of Lastprof instantiations.
        /// </summary>
        public enum Type
        {
            Detect
        }

        /// <summary>
        ///     Instantiate a Lastprof type.
        /// </summary>
        /// <param name="type">
        ///     Types of Lastprof instantiation.
        /// </param>
        /// <param name="output">
        ///     Optional output type for writing data to.
        /// </param>
        /// <returns>
        ///     Lastprof instance.
        /// </returns>
        /// <exception cref="FileNotFoundException">
        ///     Attempted to detect a lastprof.txt file and none has been found on the file system.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Invalid enum value.
        /// </exception>
        public static Lastprof Get(Type type, Output output = null)
        {
            switch (type)
            {
                case Type.Detect:
                    var myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    var txtFilePath = Path.Combine(myDocuments, "My Games", "Halo CE", Lastprof.Name);

                    if (!File.Exists(txtFilePath))
                        throw new FileNotFoundException("Could not find lastprof.txt through the detection attempt.");

                    return new Lastprof(File.ReadAllText(txtFilePath), output);
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}