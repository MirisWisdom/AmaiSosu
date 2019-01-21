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

using System;
using System.IO;
using AmaiSosu.Common;
using Microsoft.Win32;

namespace AmaiSosu.Detection
{
    public static class ExecutableFactory
    {
        /// <summary>
        ///     Types of Executable instantiations.
        /// </summary>
        public enum Type
        {
            Detect
        }

        /// <summary>
        ///     Default location set by the HCE installer.
        /// </summary>
        private const string DefaultInstall = @"C:\Program Files (x86)\Microsoft Games\Halo Custom Edition";

        /// <summary>
        ///     HCE registry keys location.
        /// </summary>
        private const string RegKeyLocation = @"SOFTWARE\Microsoft\Microsoft Games\Halo CE";

        /// <summary>
        ///     HCE executable path registry key name.
        /// </summary>
        private const string RegKeyIdentity = @"EXE Path";

        /// <summary>
        ///     Instantiate an Executable type.
        /// </summary>
        /// <param name="type">
        ///     Types of executable instantiation.
        /// </param>
        /// <param name="output">
        ///     Optional output type for writing data to.
        /// </param>
        /// <returns>
        ///     Executable instance.
        /// </returns>
        /// <exception cref="FileNotFoundException">
        ///     Attempted to detect an executable and none has been found on the file system.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Invalid enum value.
        /// </exception>
        public static Executable Get(Type type, Output output = null)
        {
            switch (type)
            {
                case Type.Detect:
                    using (var view = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                    using (var key = view.OpenSubKey(RegKeyLocation))
                    {
                        var path = key?.GetValue(RegKeyIdentity);
                        if (path != null) return new Executable($@"{path}\{Executable.Name}");
                    }

                    using (var view = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
                    using (var key = view.OpenSubKey(RegKeyLocation))
                    {
                        var path = key?.GetValue(RegKeyIdentity);
                        if (path != null) return new Executable($@"{path}\{Executable.Name}");
                    }

                    var fullDefaultPath = $@"{DefaultInstall}\{Executable.Name}";
                    if (File.Exists(fullDefaultPath)) return new Executable(fullDefaultPath, output);

                    var currentDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), Executable.Name);
                    if (File.Exists(currentDirectoryPath)) return new Executable(currentDirectoryPath, output);

                    throw new FileNotFoundException("Could not find a legal executable through the detection attempt.");
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}