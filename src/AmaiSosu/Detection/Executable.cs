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

using System.Diagnostics;
using System.IO;
using AmaiSosu.Common;

namespace AmaiSosu.Detection
{
    public class Executable : Module, IVerifiable
    {
        /// <summary>
        ///     HCE executable name.
        /// </summary>
        public const string Name = "haloce.exe";

        /// <summary>
        ///     Known file length of the 1.10 executable.
        /// </summary>
        private const int ValidLength = 0x24B000;

        public Executable(string path)
        {
            Path = path;
        }

        public Executable(string path, Output output) : base(output)
        {
            Path = path;
        }

        /// <inheritdoc />
        protected override string Identifier { get; } = "Atarashii.Loader";

        /// <summary>
        ///     Executable file path.
        /// </summary>
        public string Path { get; }

        /// <inheritdoc />
        /// <returns>
        ///     False if:
        ///     - Path does not exist.
        ///     - Executable is invalid.
        /// </returns>
        public Verification Verify()
        {
            if (!File.Exists(Path))
                return new Verification(false, "The specified executable was not found.");

            if (new FileInfo(Path).Length != ValidLength)
                return new Verification(false, "The specified executable is invalid in size.");

            return new Verification(true);
        }

        /// <summary>
        ///     Executes the given HCE executable.
        /// </summary>
        /// <param name="verify">
        ///     Verify the HCE executable.
        /// </param>
        /// <exception cref="LoaderException">
        ///     The specified executable was not found.
        ///     - or -
        ///     The specified executable is deemed invalid.
        ///     - or -
        ///     Could not infer executable name from the path.
        ///     - or -
        ///     Could not infer working directory from the path.
        /// </exception>
        public void Load(bool verify = true)
        {
            if (verify)
            {
                WriteInfo("Verifying inbound executable.");

                var state = Verify();
                if (!state.IsValid) WriteAndThrow(new LoaderException(state.Reason));
            }

            WriteSuccess("Executable has been successfully verified.");
            WriteInfo("Attempting to load the executable.");

            try
            {
                new Process
                {
                    StartInfo =
                    {
                        FileName = System.IO.Path.GetFileName(Path) ??
                                   throw new LoaderException("Could not infer executable name from the path."),
                        WorkingDirectory = System.IO.Path.GetDirectoryName(Path) ??
                                           throw new LoaderException("Could not infer working directory from the path.")
                    }
                }.Start();

                WriteSuccess("Successfully loaded inbound executable.");
            }
            catch (LoaderException e)
            {
                WriteAndThrow(e);
            }
        }
    }
}