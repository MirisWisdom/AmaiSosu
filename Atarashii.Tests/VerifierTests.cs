using System;
using System.IO;
using Atarashii.Modules.Loader;
using NUnit.Framework;

namespace Atarashii.Tests
{
    [TestFixture]
    public class VerifierTests
    {
        [Test]
        public void VerifyValidExecutable_ValueIsTrue_True()
        {
            var exeName = $"{new Guid().ToString()}.exe";
            var executable = new Executable(exeName);

            File.WriteAllBytes(exeName, new byte[0x24B000]);
            Assert.IsTrue(executable.Verify().IsValid);
            File.Delete(exeName);
        }
    }
}