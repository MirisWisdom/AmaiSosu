/**
 * Copyright (C) 2018-2019 Emilian Roman
 * 
 * This file is part of HCE.AmaiSosu.
 * 
 * HCE.AmaiSosu is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * HCE.AmaiSosu is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with HCE.AmaiSosu.  If not, see <http://www.gnu.org/licenses/>.
 */

using System.IO;
using System.IO.Compression;
using AmaiSosu.Common.Exceptions;

namespace AmaiSosu.Common
{
    /// <summary>
    ///     Archive installer and verifier.
    /// </summary>
    public class Package : Module, IVerifiable
    {
        /// <summary>
        ///     Directory containing the expected packages.
        /// </summary>
        public const string Directory = "Packages";

        /// <summary>
        ///     Package archive extension.
        /// </summary>
        public const string Extension = "pkg";

        public Package(string archiveName, string description, string destination)
        {
            ArchiveName = archiveName;
            Description = description;
            Destination = destination;
        }

        public Package(string archiveName, string description, string destination, Output output)
            : base(output)
        {
            ArchiveName = archiveName;
            Description = description;
            Destination = destination;
        }

        protected override string Identifier { get; } = "Atarashii.Package";

        /// <summary>
        ///     Name of the archive file without any extensions or paths.
        /// </summary>
        public string ArchiveName { get; }

        /// <summary>
        ///     Informative line about the package.
        /// </summary>
        public string Description { get; }

        /// <summary>
        ///     Destination directory path for the installed contents.
        /// </summary>
        public string Destination { get; }

        /// <inheritdoc />
        /// False if:
        /// - Package archive does not exist.
        /// - Install destination does not exist.
        public Verification Verify()
        {
            if (!File.Exists(ArchiveName))
                return new Verification(false, "Cannot install specified package. Package archive does not exist.");

            if (!System.IO.Directory.Exists(Destination))
                return new Verification(false, "Cannot install specified package. Destination does not exist.");

            return new Verification(true);
        }

        /// <summary>
        ///     Applies the files in the package to the destination on the filesystem.
        /// </summary>
        /// <exception cref="PackageException">
        ///     Package archive does not exist.
        ///     - or -
        ///     Destination directory does not exist.
        /// </exception>
        public void Install()
        {
            WriteInfo($"Verifying {Description} package.");
            var state = Verify();

            if (!state.IsValid)
                WriteAndThrow(new PackageException(state.Reason));

            WriteSuccess($"Package {Description} has been successfully verified.");

            try
            {
                ZipFile.ExtractToDirectory(ArchiveName, Destination);
            }
            catch (IOException)
            {
                WriteWarn($"{Description} data already exists. This is fine!");
            }

            WriteSuccess($"{Description} data has been installed successfully to the filesystem.");
        }
    }
}