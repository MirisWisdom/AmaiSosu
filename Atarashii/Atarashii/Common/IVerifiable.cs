namespace Atarashii.Common
{
    public interface IVerifiable
    {
        /// <summary>
        ///     Verifies the state validity.
        /// </summary>
        /// <returns>
        ///     Verification type representing the state's validity.
        /// </returns>
        Verification Verify();
    }
}