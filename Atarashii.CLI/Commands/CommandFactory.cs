using Atarashii.Common;

namespace Atarashii.CLI.Commands
{
    public class CommandFactory
    {
        public static Command Get(string command, Output output)
        {
            switch (command)
            {
                case nameof(Loader):
                    return new Loader(output);
                case nameof(OpenSauce):
                    return new OpenSauce(output);
                case nameof(Profile):
                    return new Profile(output);
                default:
                    throw new CommandFactoryException("Invalid command given.");
            }
        }
    }
}