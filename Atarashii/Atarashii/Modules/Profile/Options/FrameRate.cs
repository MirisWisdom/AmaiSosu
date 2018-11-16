namespace Atarashii.Modules.Profile.Options
{
    /// <summary>
    ///     Representation of the video frame rate settings.
    /// </summary>
    public class FrameRate
    {
        /// <summary>
        ///     Available frame rate types.
        /// </summary>
        public enum Type
        {
            VsyncOff,
            VsyncOn,
            Fps30,
        }

        /// <summary>
        ///     Frame rate type value.
        /// </summary>
        public Type Value { get; set; } = Type.Fps30;
    }
}