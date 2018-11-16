using Atarashii.Modules.OpenSauce;
using Atarashii.Modules.OpenSauce.Options;
using NUnit.Framework;

namespace Atarashii.Tests
{
    [TestFixture]
    public class OpenSauceTests
    {
        private readonly string _result = new Configuration().ToXml();

        [Test]
        public void FromXml_PropertyValueIsCorrect_True()
        {
            var object01 = new Configuration
            {
                Camera = new Camera
                {
                    FieldOfView = 128.64
                }
            };

            var object02 = ConfigurationFactory.GetFromXml(object01.ToXml());
            Assert.AreEqual(object02.Camera.FieldOfView, object01.Camera.FieldOfView);
        }

        [Test]
        public void ToXml_BooleansAreCorrect_True()
        {
            StringAssert.Contains("<DepthFade>true</DepthFade>", _result);
        }

        [Test]
        public void ToXml_NumbersAreCorrect_True()
        {
            StringAssert.Contains("<FieldOfView>70</FieldOfView>", _result);
        }
    }
}