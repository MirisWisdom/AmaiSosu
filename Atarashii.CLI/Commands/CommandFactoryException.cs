using System;
using System.Runtime.Serialization;

namespace Atarashii.CLI.Commands
{
    [Serializable]
    public class CommandFactoryException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public CommandFactoryException()
        {
        }

        public CommandFactoryException(string message) : base(message)
        {
        }

        public CommandFactoryException(string message, Exception inner) : base(message, inner)
        {
        }

        protected CommandFactoryException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}