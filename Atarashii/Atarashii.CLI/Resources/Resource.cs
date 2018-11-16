using System.IO;

namespace Atarashii.CLI.Resources
{
    public class Resource
    {
        private readonly string _name;

        /// <param name="name">
        ///     Fully qualified embedded resource name.
        /// </param>
        public Resource(string name)
        {
            _name = name;
        }

        /// <summary>
        ///     Reads data from an embedded resource.
        /// </summary>
        /// <returns>
        ///     Data read from the embedded resource.
        /// </returns>
        public string Text
        {
            get
            {
                using (var stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(_name))
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}