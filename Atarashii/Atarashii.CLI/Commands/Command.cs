using System;
using System.Linq;
using Atarashii.Common;

namespace Atarashii.CLI.Commands
{
    /// <summary>
    ///     Abstract type representing an invokable Atarashii CLI command.
    /// </summary>
    public abstract class Command
    {
        protected readonly Output Output;

        protected Command(Output output)
        {
            Output = output;
        }

        /// <summary>
        ///     Initialises the command logic.
        /// </summary>
        /// <param name="commands">
        ///     Additional sub-commands or arguments for the invoked command.
        /// </param>
        public abstract void Initialise(string[] commands);

        /// <summary>
        ///     Outputs a Type.Success message.
        /// </summary>
        /// <param name="message">
        ///     Message to write.
        /// </param>
        protected void Pass(string message)
        {
            Output?.WriteSuccess(Assembly.ProductName, message);
        }

        /// <summary>
        ///     Outputs a Type.Info message.
        /// </summary>
        /// <param name="message">
        ///     Message to write.
        /// </param>
        protected void Info(string message)
        {
            Output?.WriteInfo(Assembly.ProductName, message);
        }

        /// <summary>
        ///     Outputs the inbound error code and exits the application.
        /// </summary>
        /// <param name="message">
        ///     Message to output.
        /// </param>
        /// <param name="code">
        ///     Error code to use for exiting.
        /// </param>
        protected void Fail(string message, int code)
        {
            Output?.WriteError(Assembly.ProductName, message);
            Environment.Exit(code);
        }

        /// <summary>
        ///     Outputs a Type.Dump message.
        /// </summary>
        /// <param name="message">
        ///     Message to write.
        /// </param>
        protected void Dump(string message)
        {
            Output?.WriteDump(Assembly.ProductName, message);
        }

        /// <summary>
        ///     Exits the program if the inbound arguments are empty.
        /// </summary>
        /// <param name="args">
        ///     Arguments to check the length of.
        /// </param>
        public void ExitIfNone(string[] args)
        {
            if (args.Length == 0) Fail("Not enough or commands arguments provided.", 1);
        }

        /// <summary>
        ///     Removes the command (first argument) from an arguments array.
        /// </summary>
        /// <param name="command">
        ///     Arguments array to remove the command from.
        /// </param>
        /// <returns>
        ///     Arguments array without the command.
        /// </returns>
        public static string[] GetArguments(string[] command)
        {
            return command.Skip(1).ToArray();
        }
    }
}