using System;
using System.Collections.Generic;
using System.IO;
using Atarashii.Common;
using Atarashii.Modules.Loader;
using Atarashii.Modules.OpenSauce;
using NUnit.Framework;

namespace Atarashii.Tests
{
    [TestFixture]
    public class OpenSauceInstallerTests
    {
        private readonly List<Package> _packages = new List<Package>
        {
            new Package(new Guid().ToString(), new Guid().ToString(), new Guid().ToString())
        };

        [Test]
        public void InstallNonExistentPackage_ThrowsException()
        {
            var hcePath = new Guid().ToString();
            var hceFile = Path.Combine(hcePath, Executable.Name);

            Directory.CreateDirectory(hcePath);
            File.WriteAllBytes(hceFile, new byte[256]);

            var installer = new Installer(hcePath, _packages);

            var ex = Assert.Throws<OpenSauceException>(() => installer.Install());
            Assert.That(ex.Message,
                Is.EqualTo("Cannot install specified package. Package archive does not exist."));

            File.Delete(hceFile);
            Directory.Delete(hcePath);
        }

        [Test]
        public void InstallToInvalidHceDirectory_ThrowsException()
        {
            var hcePath = new Guid().ToString();
            var installer = new Installer(hcePath, _packages);

            Directory.CreateDirectory(hcePath);

            var ex = Assert.Throws<OpenSauceException>(() => installer.Install());
            Assert.That(ex.Message, Is.EqualTo("Invalid target HCE directory path for OpenSauce installation."));

            Directory.Delete(hcePath);
        }

        [Test]
        public void InstallToNonExistentDirectory_ThrowsException()
        {
            var fakePath = new Guid().ToString();
            var installer = new Installer(fakePath, _packages);

            var ex = Assert.Throws<OpenSauceException>(() => installer.Install());
            Assert.That(ex.Message,
                Is.EqualTo("Target directory for OpenSauce installation does not exist."));
        }

        [Test]
        public void VerifyInvalidHceDirectory_ReturnsFalse()
        {
            var hcePath = new Guid().ToString();
            var installer = new Installer(hcePath, _packages);

            Directory.CreateDirectory(hcePath);
            Assert.IsFalse(installer.Verify().IsValid);
            Directory.Delete(hcePath);
        }

        [Test]
        public void VerifyNonExistentDirectory_ReturnsFalse()
        {
            var fakePath = new Guid().ToString();
            var installer = new Installer(fakePath, _packages);
            Assert.IsFalse(installer.Verify().IsValid);
        }

        [Test]
        public void VerifyNonExistentPackage_ReturnsFalse()
        {
            var hcePath = new Guid().ToString();
            var hceFile = Path.Combine(hcePath, Executable.Name);

            Directory.CreateDirectory(hcePath);
            File.WriteAllBytes(hceFile, new byte[256]);

            var installer = new Installer(hcePath, _packages);
            Assert.IsFalse(installer.Verify().IsValid);

            File.Delete(hceFile);
            Directory.Delete(hcePath);
        }
    }
}