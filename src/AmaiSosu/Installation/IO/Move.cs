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

using System.Collections.Generic;

namespace AmaiSosu.Installation.IO
{
    /// <summary>
    ///     Abstract representing a type that conducts data migration.
    /// </summary>
    public abstract class Move
    {
        /// <summary>
        ///     Backup constructor.
        /// </summary>
        /// <param name="data">
        ///     <see cref="Data" />
        /// </param>
        /// <param name="sourceDirectory">
        ///     <see cref="SourceDirectory" />
        /// </param>
        /// <param name="targetDirectory">
        ///     <see cref="TargetDirectory" />
        /// </param>
        protected Move(List<string> data, string sourceDirectory, string targetDirectory)
        {
            Data = data;
            SourceDirectory = sourceDirectory;
            TargetDirectory = targetDirectory;
        }

        /// <summary>
        ///     List of data inside <see cref="SourceDirectory" />.
        /// </summary>
        protected List<string> Data { get; }

        /// <summary>
        ///     The directory containing the Data.
        /// </summary>
        protected string SourceDirectory { get; }

        /// <summary>
        ///     The directory where the SourceDirectory Data should be moved to.
        /// </summary>
        protected string TargetDirectory { get; }

        /// <summary>
        ///     Conducts the backup routine on the given constructor arguments.
        /// </summary>
        public abstract void Commit();
    }
}