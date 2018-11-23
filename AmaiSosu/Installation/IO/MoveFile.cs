using System.Collections.Generic;
using System.IO;

namespace AmaiSosu.Installation.IO
{
    /// <inheritdoc />
    public class MoveFile : Move
    {
        public MoveFile(List<string> data, string sourceDirectory, string targetDirectory) : base(data,
            sourceDirectory, targetDirectory)
        {
            // call parent constructor
        }

        /// <inheritdoc />
        public override void Commit()
        {
            foreach (var file in Data)
            {
                var source = Path.Combine(SourceDirectory, file);
                var target = Path.Combine(TargetDirectory, file);

                if (File.Exists(source))
                    File.Move(source, target);
            }
        }
    }
}