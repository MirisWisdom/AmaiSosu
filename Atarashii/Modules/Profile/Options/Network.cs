namespace Atarashii.Modules.Profile.Options
{
    /// <summary>
    ///     Profile network settings.
    /// </summary>
    public class Network
    {
        /// <summary>
        ///     Connection type settings.
        /// </summary>
        public Connection Connection = new Connection();

        /// <summary>
        ///     Network ports.
        /// </summary>
        public Port Port { get; set; } = new Port();
    }
}