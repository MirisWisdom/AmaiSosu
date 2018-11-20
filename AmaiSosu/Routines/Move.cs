using System.Collections.Generic;

namespace AmaiSosu.Routines
{
    /// <summary>
    ///     Abstract representing a type that conducts data migration.
    /// </summary>
    public abstract class Move
    {
        /// <summary>
        ///     Backup constructor.
        /// </summary>
        /// <param name="data">
        ///     <see cref="Data" />
        /// </param>
        /// <param name="sourceDirectory">
        ///     <see cref="SourceDirectory" />
        /// </param>
        /// <param name="targetDirectory">
        ///     <see cref="TargetDirectory" />
        /// </param>
        protected Move(List<string> data, string sourceDirectory, string targetDirectory)
        {
            Data = data;
            SourceDirectory = sourceDirectory;
            TargetDirectory = targetDirectory;
        }

        /// <summary>
        ///     List of data inside <see cref="SourceDirectory" />.
        /// </summary>
        protected List<string> Data { get; }

        /// <summary>
        ///     The directory containing the Data.
        /// </summary>
        protected string SourceDirectory { get; }

        /// <summary>
        ///     The directory where the SourceDirectory Data should be moved to.
        /// </summary>
        protected string TargetDirectory { get; }

        /// <summary>
        ///     Conducts the backup routine on the given constructor arguments.
        /// </summary>
        public abstract void Commit();
    }
}