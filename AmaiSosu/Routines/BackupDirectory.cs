using System.Collections.Generic;
using System.IO;

namespace AmaiSosu.Routines
{
    /// <inheritdoc />
    public class BackupDirectory : Backup
    {
        public BackupDirectory(List<string> data, string sourceDirectory, string targetDirectory) : base(data,
            sourceDirectory, targetDirectory)
        {
            // call parent constructor
        }

        /// <inheritdoc />
        public override void Commit()
        {
            foreach (var dir in Data)
            {
                var source = Path.Combine(SourceDirectory, dir);
                var target = Path.Combine(TargetDirectory, dir);

                if (Directory.Exists(source))
                    Directory.Move(source, target);
            }
        }
    }
}