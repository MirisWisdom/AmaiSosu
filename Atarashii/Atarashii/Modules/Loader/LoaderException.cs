using System;
using System.Runtime.Serialization;

namespace Atarashii.Modules.Loader
{
    [Serializable]
    public class LoaderException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public LoaderException()
        {
        }

        public LoaderException(string message) : base(message)
        {
        }

        public LoaderException(string message, Exception inner) : base(message, inner)
        {
        }

        protected LoaderException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}