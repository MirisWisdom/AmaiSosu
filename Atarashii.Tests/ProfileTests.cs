using System;
using System.IO;
using Atarashii.Modules.Profile;
using Atarashii.Modules.Profile.Options;
using NUnit.Framework;

namespace Atarashii.Tests
{
    [TestFixture]
    public class ProfileTests
    {
        private readonly Configuration _configuration =
            ConfigurationFactory.GetFromStream(new MemoryStream(ProfileTestData.blam));

        [Test]
        public void InvalidName_ThrowsException_True()
        {
            var configuration = new Configuration();

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => configuration.Name.Value = "Hello from Gensokyo");
            StringAssert.Contains("Assigned name value is greater than 11 characters.", ex.Message);
        }

        [Test]
        public void InvalidResolution_ThrowsException_True()
        {
            var configuration = new Configuration();

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => configuration.Video.Resolution.Width = 0);
            StringAssert.Contains("Assigned dimension value is either 0 or over 32767.", ex.Message);
        }

        [Test]
        public void InvalidSensitivity_ThrowsException_True()
        {
            var configuration = new Configuration();

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => configuration.Mouse.Sensitivity.Horizontal = 11);
            StringAssert.Contains("Assigned sensitivity value is less than 1 or greater than 10.", ex.Message);
        }

        [Test]
        public void InvalidVolume_ThrowsException_True()
        {
            var configuration = new Configuration();

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => configuration.Audio.Volume.Music = 15);
            StringAssert.Contains("Assigned volume value is greater than 10.", ex.Message);
        }

        [Test]
        public void ProfileParsing_AudioQualityCorrect_True()
        {
            Assert.That(_configuration.Audio.Quality.Value, Is.EqualTo(Quality.Type.Medium));
        }

        [Test]
        public void ProfileParsing_AudioVarietyIsCorrect_True()
        {
            Assert.That(_configuration.Audio.Variety.Value, Is.EqualTo(Quality.Type.High));
        }

        [Test]
        public void ProfileParsing_AudioVolumeIsCorrect_True()
        {
            Assert.That(_configuration.Audio.Volume.Master, Is.EqualTo(10));
            Assert.That(_configuration.Audio.Volume.Effects, Is.EqualTo(10));
            Assert.That(_configuration.Audio.Volume.Music, Is.EqualTo(6));
        }

        [Test]
        public void ProfileParsing_ColourIsCorrect_True()
        {
            Assert.That(_configuration.Colour.Value, Is.EqualTo(Colour.Type.White));
        }

        [Test]
        public void ProfileParsing_MouseAxisInversionIsCorrect_True()
        {
            Assert.That(_configuration.Mouse.InvertVerticalAxis, Is.EqualTo(false));
        }

        [Test]
        public void ProfileParsing_MouseSensitivityIsCorrect_True()
        {
            Assert.That(_configuration.Mouse.Sensitivity.Horizontal, Is.EqualTo(3));
            Assert.That(_configuration.Mouse.Sensitivity.Vertical, Is.EqualTo(3));
        }

        [Test]
        public void ProfileParsing_NameIsCorrect_True()
        {
            Assert.That(_configuration.Name.Value, Is.EqualTo("New001"));
        }

        [Test]
        public void ProfileParsing_NetworkPortsAreCorrect_True()
        {
            Assert.That(_configuration.Network.Port.Server, Is.EqualTo(2302));
            Assert.That(_configuration.Network.Port.Client, Is.EqualTo(2303));
        }

        [Test]
        public void ProfileParsing_NetworkTypeIsCorrect_True()
        {
            Assert.That(_configuration.Network.Connection.Value, Is.EqualTo(Connection.Type.DslLow));
        }

        [Test]
        public void ProfileParsing_VideoEffectsAreCorrect_True()
        {
            Assert.That(_configuration.Video.Effects.Specular, Is.EqualTo(true));
            Assert.That(_configuration.Video.Effects.Shadows, Is.EqualTo(true));
            Assert.That(_configuration.Video.Effects.Decals, Is.EqualTo(true));
        }

        [Test]
        public void ProfileParsing_VideoFrameRateIsCorrect_True()
        {
            Assert.That(_configuration.Video.FrameRate.Value, Is.EqualTo(FrameRate.Type.Fps30));
        }

        [Test]
        public void ProfileParsing_VideoParticlesIsCorrect_True()
        {
            Assert.That(_configuration.Video.Particles.Value, Is.EqualTo(Particles.Type.High));
        }

        [Test]
        public void ProfileParsing_VideoQualityIsCorrect_True()
        {
            Assert.That(_configuration.Video.Particles.Value, Is.EqualTo(Particles.Type.High));
        }

        [Test]
        public void ProfileParsing_VideoResolutionIsCorrect_True()
        {
            Assert.That(_configuration.Video.Resolution.Width, Is.EqualTo(800));
            Assert.That(_configuration.Video.Resolution.Height, Is.EqualTo(600));
        }
    }
}