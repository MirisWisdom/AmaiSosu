namespace Atarashii.CLI
{
    /// <summary>
    ///     Various
    /// </summary>
    public enum ExitType
    {
        /// <summary>
        ///     Invoked command has been executed successfully.
        /// </summary>
        Success = 0,

        /// <summary>
        ///     Not enough arguments have been provided for the specified command.
        /// </summary>
        NotEnoughArguments,

        /// <summary>
        ///     Incorrect arguments have been provided to the specified command.
        /// </summary>
        IncorrectArguments,

        /// <summary>
        ///     An exception has occurred when executing the invoked command.
        /// </summary>
        Exception
    }
}