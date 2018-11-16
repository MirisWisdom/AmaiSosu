using System;
using System.IO;
using Atarashii.Common;
using Atarashii.Modules.Loader;

namespace Atarashii.CLI.Commands
{
    /// <inheritdoc />
    /// <summary>
    ///     CLI front-end for loading a HCE executable.
    /// </summary>
    internal class Loader : Command
    {
        public Loader(Output output) : base(output)
        {
        }

        public override void Initialise(string[] commands)
        {
            ExitIfNone(commands);
            var args = GetArguments(commands);

            switch (commands[0])
            {
                case nameof(Load):
                    Load(args);
                    break;
                case nameof(Detect):
                    Detect();
                    break;
                default:
                    Fail("Invoked an invalid Load command.", ExitType.IncorrectArguments);
                    break;
            }
        }

        private void Load(string[] args)
        {
            Info("Invoked the Loader.Load command.");
            ExitIfNone(args);

            try
            {
                var executable = new Executable(args[0], Output);
                executable.Load();
            }
            catch (LoaderException e)
            {
                Fail(e.Message, ExitType.Exception);
            }
            catch (Exception e)
            {
                Fail(e.Message, ExitType.Exception);
            }
        }

        private void Detect()
        {
            Info("Invoked the Loader.Detect command.");
            Info("Attempting to detect executable path.");

            try
            {
                Console.WriteLine(ExecutableFactory.Get(ExecutableFactory.Type.Detect, Output).Path);
            }
            catch (FileNotFoundException e)
            {
                Fail(e.Message, ExitType.Exception);
            }
        }
    }
}