namespace Atarashii.Modules.Profile.Options
{
    /// <summary>
    ///     Representation of a generic quality-type value, e.g. texture, audio.
    /// </summary>
    public class Quality
    {
        /// <summary>
        ///     Generic quality level values.
        /// </summary>
        public enum Type
        {
            Low,
            Medium,
            High
        }

        /// <summary>
        ///     Chosen quality level.
        /// </summary>
        public Type Value { get; set; } = Type.High;
    }
}