using System.Collections.Generic;
using System.IO;

namespace AmaiSosu.Installation.IO
{
    /// <inheritdoc />
    public class MoveDirectory : Move
    {
        public MoveDirectory(List<string> data, string sourceDirectory, string targetDirectory) : base(data,
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