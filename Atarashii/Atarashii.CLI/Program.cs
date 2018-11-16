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
            }
            catch (IndexOutOfRangeException)
            {
                Environment.Exit(1);
            }
            catch (CommandFactoryException e)
            {
                output.Write(Output.Type.Error, Assembly.ProductName, e.Message);
                Environment.Exit(2);
            }
        }
    }
}