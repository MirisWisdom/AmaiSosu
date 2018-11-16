namespace Atarashii.Modules.Profile.Options
{
    /// <summary>
    ///     Representation of the video effects settings.
    /// </summary>
    public class Effects
    {
        /// <summary>
        ///     Shadow effects toggle.
        /// </summary>
        public bool Shadows { get; set; } = true;

        /// <summary>
        ///     Specular effects toggle.
        /// </summary>
        public bool Specular { get; set; } = true;

        /// <summary>
        ///     Decals effects toggle.
        /// </summary>
        public bool Decals { get; set; } = true;
    }
}