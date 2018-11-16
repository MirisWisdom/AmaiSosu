namespace Atarashii.Modules.Profile.Options
{
    /// <summary>
    ///     Representation of the profile player colour.
    /// </summary>
    public class Colour
    {
        /// <summary>
        ///     Available player colours.
        /// </summary>
        public enum Type
        {
            White,
            Black,
            Red,
            Blue,
            Gray,
            Yellow,
            Green,
            Pink,
            Purple,
            Cyan,
            Cobalt,
            Orange,
            Teal,
            Sage,
            Brown,
            Tan,
            Maroon,
            Salmon
        }

        /// <summary>
        ///     Player colour value.
        /// </summary>
        public Type Value { get; set; } = Type.White;
    }
}