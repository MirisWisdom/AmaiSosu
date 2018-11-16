using System.Xml.Serialization;

namespace Atarashii.Modules.OpenSauce.Options
{
    public class ShaderExtensions
    {
        public bool Enabled = true;

        [XmlElement(ElementName = "Rasterizer")]
        public ShaderRasterizer ShaderRasterizer { get; set; } = new ShaderRasterizer();
    }
}