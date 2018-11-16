using System.Xml.Serialization;

namespace Atarashii.Modules.OpenSauce.Options
{
    public class ShaderRasterizer
    {
        [XmlElement(ElementName = "ShaderExtensions")]
        public RasterizerShaderExtensions RasterizerShaderExtensions { get; set; } = new RasterizerShaderExtensions();
    }
}