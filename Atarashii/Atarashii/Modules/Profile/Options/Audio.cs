namespace Atarashii.Modules.Profile.Options
{
    // TODO: Handle HW Acceleration & Environmental Sound.

    /// <summary>
    ///     Representation of the profile audio settings.
    /// </summary>
    public class Audio
    {
        /// <summary>
        ///     Audio volume.
        /// </summary>
        public Volume Volume { get; set; } = new Volume();

        /// <summary>
        ///     Audio quality.
        /// </summary>
        public Quality Quality { get; set; } = new Quality();

        /// <summary>
        ///     Audio variety.
        /// </summary>
        public Quality Variety { get; set; } = new Quality();
    }
}