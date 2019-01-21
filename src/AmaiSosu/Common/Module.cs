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

namespace AmaiSosu.Common
{
    /// <summary>
    ///     Abstract type representing an Atarashii module.
    /// </summary>
    public abstract class Module
    {
        /// <summary>
        ///     Module constructor.
        /// </summary>
        /// <param name="output">
        ///     Optional Output type for writing messages to.
        /// </param>
        protected Module(Output output = null)
        {
            Output = output;
        }

        /// <summary>
        ///     Name of the module to be used in contexts such as output subjects.
        /// </summary>
        protected abstract string Identifier { get; }

        /// <summary>
        ///     Optional Output type for writing messages to.
        /// </summary>
        private Output Output { get; }

        /// <summary>
        ///     Invokes the Output.Write with the inbound exception message, then throws the exception.
        /// </summary>
        /// <param name="exception">
        ///     Exception to write and throw.
        /// </param>
        /// <exception cref="Exception">
        ///     Exception which will be thrown.
        /// </exception>
        protected void WriteAndThrow(Exception exception)
        {
            WriteError($"{nameof(Exception)} thrown: " + exception.Message);
            throw exception;
        }

        /// <summary>
        ///     Writes a Type.Success message w/ Module Name as the subject.
        /// </summary>
        /// <param name="message">
        ///     Message to write to the Output instance.
        /// </param>
        protected void WriteSuccess(string message)
        {
            Output?.WriteSuccess(Identifier, message);
        }

        /// <summary>
        ///     Writes a Type.Info message w/ Module Name as the subject.
        /// </summary>
        /// <param name="message">
        ///     Message to write to the Output instance.
        /// </param>
        protected void WriteInfo(string message)
        {
            Output?.WriteInfo(Identifier, message);
        }

        /// <summary>
        ///     Writes a Type.Warn message w/ Module Name as the subject.
        /// </summary>
        /// <param name="message">
        ///     Message to write to the Output instance.
        /// </param>
        protected void WriteWarn(string message)
        {
            Output?.WriteWarn(Identifier, message);
        }

        /// <summary>
        ///     Writes a Type.Error message w/ Module Name as the subject.
        /// </summary>
        /// <param name="message">
        ///     Message to write to the Output instance.
        /// </param>
        protected void WriteError(string message)
        {
            Output?.WriteError(Identifier, message);
        }
    }
}