using System.IO;
using System.Xml.Serialization;

namespace Atarashii.Modules.OpenSauce
{
    /// <summary>
    ///     Creates OpenSauce Configuration instances.
    /// </summary>
    public static class ConfigurationFactory
    {
        /// <summary>
        ///     Deserialises a given XML string to an OpenSauce Configuration instance.
        /// </summary>
        /// <param name="xml">
        ///     XML representation of a serialised OpenSauce Configuration object.
        /// </param>
        /// <returns>
        ///     OpenSauce Configuration object instance.
        /// </returns>
        public static Configuration GetFromXml(string xml)
        {
            var stringReader = new StringReader(xml);
            var serializer = new XmlSerializer(typeof(Configuration));
            return serializer.Deserialize(stringReader) as Configuration;
        }
    }
}