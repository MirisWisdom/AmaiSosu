using System;
using System.IO;
using Atarashii.Common;
using Atarashii.Modules.OpenSauce;

namespace Atarashii.CLI.Commands
{
    /// <inheritdoc />
    internal class OpenSauce : Command
    {
        public OpenSauce(Output output) : base(output)
        {
        }

        public override void Initialise(string[] commands)
        {
            ExitIfNone(commands);
            var args = GetArguments(commands);

            switch (commands[0])
            {
                case nameof(Install):
                    Install(args);
                    break;
                case nameof(Dump):
                    Dump(args);
                    break;
                default:
                    Fail("Invoked an invalid OpenSauce command.", 2);
                    break;
            }
        }

        private void Install(string[] args)
        {
            Info("Invoked the OpenSauce.Install command.");
            ExitIfNone(args);

            try
            {
                new InstallerFactory(args[0], Output).Get().Install();
            }
            catch (OpenSauceException)
            {
                Environment.Exit(1);
            }
            catch (Exception)
            {
                Environment.Exit(2);
            }
        }

        private void Dump(string[] args)
        {
            Info("Invoked the OpenSauce.Parse command.");
            ExitIfNone(args);

            try
            {
                Console.WriteLine();
                using (var reader = new StringReader(File.ReadAllText(args[0])))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Dump(line);
                    }
                }
                Console.WriteLine();
                Pass("Successfully dumped data from the provided OpenSauce XML file.");
            }
            catch (Exception e)
            {
                Fail(e.Message, 3);
            }
        }
    }
}