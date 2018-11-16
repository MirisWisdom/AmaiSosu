using System.Xml.Serialization;

namespace Atarashii.Modules.OpenSauce.Options
{
    public class RasterizerShaderExtensions
    {
        [XmlElement(ElementName = "Object")] public ShaderObject ShaderObject { get; set; } = new ShaderObject();

        [XmlElement(ElementName = "Environment")]
        public ShaderEnvironment ShaderEnvironment { get; set; } = new ShaderEnvironment();

        public Effect Effect { get; set; } = new Effect();
    }
}