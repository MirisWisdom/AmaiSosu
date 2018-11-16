using System.IO;
using System.Xml.Serialization;
using Atarashii.Modules.OpenSauce.Options;

namespace Atarashii.Modules.OpenSauce
{
    /// <summary>
    ///     This type is used to represent an OpenSauce user XML configuration as an object.
    /// </summary>
    public class Configuration
    {
        public CacheFiles CacheFiles { get; set; } = new CacheFiles();

        public Rasterizer Rasterizer { get; set; } = new Rasterizer();

        public Camera Camera { get; set; } = new Camera();

        public Networking Networking { get; set; } = new Networking();

        public Objects Objects { get; set; } = new Objects();

        [XmlElement(ElementName = "HUD")] public Hud Hud { get; set; } = new Hud();

        /// <summary>
        ///     Converts this instance to an XML string.
        /// </summary>
        /// <returns>
        ///     XML representation of this instance.
        /// </returns>
        public string ToXml()
        {
            using (var writer = new StringWriter())
            {
                var serialiser = new XmlSerializer(typeof(Configuration));
                serialiser.Serialize(writer, this);
                return writer.ToString();
            }
        }
    }
}