using System;
using System.IO;
using Atarashii.Common;
using Atarashii.Common.Exceptions;
using NUnit.Framework;

namespace Atarashii.Tests
{
    [TestFixture]
    public class PackageTests
    {
        [Test]
        public void DirectoryNotFound_ThrowsException()
        {
            var package = new Package(new Guid().ToString(), "Non-existent package!", "Directory that does not exist!");
            File.WriteAllBytes(package.ArchiveName, new byte[256]);

            var ex = Assert.Throws<PackageException>(() => package.Install());
            Assert.That(ex.Message, Is.EqualTo("Cannot install specified package. Destination does not exist."));

            File.Delete(package.ArchiveName);
        }

        [Test]
        public void PackageNotFound_ThrowsException()
        {
            var package = new Package(new Guid().ToString(), "Non-existent package!", string.Empty);

            var ex = Assert.Throws<PackageException>(() => package.Install());
            Assert.That(ex.Message, Is.EqualTo("Cannot install specified package. Package archive does not exist."));
        }

        [Test]
        public void VerifyDirectoryNotFound_ReturnsFalse()
        {
            var package = new Package(new Guid().ToString(), "Non-existent package!", "Directory that does not exist!");
            File.WriteAllBytes(package.ArchiveName, new byte[256]);
            Assert.IsFalse(package.Verify().IsValid);
            File.Delete(package.ArchiveName);
        }

        [Test]
        public void VerifyPackageNotFound_ReturnsFalse()
        {
            var package = new Package(new Guid().ToString(), "Non-existent package!", string.Empty);
            Assert.IsFalse(package.Verify().IsValid);
        }
    }
}