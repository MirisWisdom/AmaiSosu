using System.Xml.Serialization;

namespace Atarashii.Modules.OpenSauce.Options
{
    public class Rasterizer
    {
        [XmlElement(ElementName = "GBuffer")] public Gbuffer Gbuffer { get; set; } = new Gbuffer();

        public Upgrades Upgrades { get; set; } = new Upgrades();

        public ShaderExtensions ShaderExtensions { get; set; } = new ShaderExtensions();

        public PostProcessing PostProcessing { get; set; } = new PostProcessing();
    }
}