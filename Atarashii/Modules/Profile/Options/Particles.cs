namespace Atarashii.Modules.Profile.Options
{
    /// <summary>
    ///     Representation of the video particles settings.
    /// </summary>
    public class Particles
    {
        /// <summary>
        ///     Particle levels.
        /// </summary>
        public enum Type
        {
            Off,
            Low,
            High
        }

        /// <summary>
        ///     Particle levels value.
        /// </summary>
        public Type Value { get; set; } = Type.High;
    }
}