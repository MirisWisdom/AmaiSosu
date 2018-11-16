namespace Atarashii.Modules.Profile.Options
{
    /// <summary>
    ///     Representation of the profile mouse settings.
    /// </summary>
    public class Mouse
    {
        /// <summary>
        ///     Mouse sensitivity.
        /// </summary>
        public Sensitivity Sensitivity { get; set; } = new Sensitivity();

        /// <summary>
        ///     Invert the vertical axis.
        /// </summary>
        public bool InvertVerticalAxis { get; set; } = false;
    }
}