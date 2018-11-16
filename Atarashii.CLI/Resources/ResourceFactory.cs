using System;

namespace Atarashii.CLI.Resources
{
    /// <summary>
    ///     Instantiates Resource types.
    /// </summary>
    public static class ResourceFactory
    {
        public enum Type
        {
            /// <summary>
            ///     Representation of the CLI ASCII banner resource.
            /// </summary>
            Banner,

            /// <summary>
            ///     Representation of the Git repository revision.
            /// </summary>
            Revision,

            /// <summary>
            ///     Representation of the CLI usage table resource.
            /// </summary>
            Usage
        }

        /// <summary>
        ///     Name of the text file containing the banner ASCII art.
        /// </summary>
        private const string BannerResourceName = "BANNER";

        /// <summary>
        ///     Name of the text file containing the Git revision.
        /// </summary>
        private const string RevisionResourceName = "REVISION";

        /// <summary>
        ///     Name of the text file containing the usage table.
        /// </summary>
        private const string UsageResourceName = "USAGE";

        /// <summary>
        ///     The location of the resource files. Conventionally, it's the namespace of the Resource type.
        /// </summary>
        private static readonly string Location = typeof(Resource).Namespace;

        /// <summary>
        ///     Returns a Resource instance based on the inbound type.
        /// </summary>
        public static Resource Get(Type type)
        {
            switch (type)
            {
                case Type.Banner:
                    return new Resource($"{Location}.{BannerResourceName}");
                case Type.Revision:
                    return new Resource($"{Location}.{RevisionResourceName}");
                case Type.Usage:
                    return new Resource($"{Location}.{UsageResourceName}");
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}