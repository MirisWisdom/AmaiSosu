using System;
using System.Runtime.Serialization;

namespace Atarashii.Common.Exceptions
{
    [Serializable]
    public class VerifierException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public VerifierException()
        {
        }

        public VerifierException(string message) : base(message)
        {
        }

        public VerifierException(string message, Exception inner) : base(message, inner)
        {
        }

        protected VerifierException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}