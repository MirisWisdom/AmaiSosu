using System;
using Atarashii.CLI.Commands;
using Atarashii.Common;

namespace Atarashii.CLI
{
    internal class Program
    {
        /// <summary>
        ///     Main entry to the Atarashii CLI.
        /// </summary>
        /// <param name="commands">
        ///     The command to invoke.
        /// </param>
        public static void Main(string[] commands)
        {
            var output = new CliOutput();
            output.WriteBanner();

            try
            {
                CommandFactory.Get(commands[0], output).Initialise(Command.GetArguments(commands));
                Exit(ExitType.Success);
            }
            catch (IndexOutOfRangeException)
            {
                Exit(ExitType.Exception);
            }
            catch (CommandFactoryException e)
            {
                output.Write(Output.Type.Error, Assembly.ProductName, e.Message);
                Exit(ExitType.Exception);
            }
        }

        /// <summary>
        ///     Wrapper for the Environment Exit method.
        /// </summary>
        /// <param name="exitType">
        ///     Exit type, which will be passed to the Environment Exit method as an integer.
        /// </param>
        private static void Exit(ExitType exitType)
        {
            Environment.Exit((int) exitType);
        }
    }
}