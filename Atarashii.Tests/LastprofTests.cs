using Atarashii.Modules.Profile;
using NUnit.Framework;

namespace Atarashii.Tests
{
    [TestFixture]
    public class LastprofTests
    {
        [Test]
        public void ParseTest_CorrectProfileName_True()
        {
            var lastprof = new Lastprof(@"E:\roman\Documents\My Games\Halo CE\savegames\Miris\ lam.sav           ");
            Assert.That(lastprof.Parse(), Is.EqualTo("Miris"));
        }
    }
}