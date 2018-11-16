using System;

namespace Atarashii.Modules.Profile.Options
{
    /// <summary>
    ///     Representation of the profile player name.
    /// </summary>
    public class Name
    {
        /// <summary>
        ///     Player name value.
        ///     This value is expected to be between 1 and 11 characters.
        /// </summary>
        private string _value = "New001";

        /// <summary>
        ///     Player name value.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        ///     No name value has been been assigned.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Assigned name value is greater than 11 characters.
        /// </exception>
        public string Value
        {
            get => _value;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(value);

                if (value.Length > 0xB)
                    throw new ArgumentOutOfRangeException(nameof(value),
                        "Assigned name value is greater than 11 characters.");

                _value = value;
            }
        }
    }
}