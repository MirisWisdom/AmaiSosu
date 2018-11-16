using System;

namespace Atarashii.Modules.Profile.Options
{
    /// <summary>
    ///     Representation of the profile mouse sensitivity settings.
    /// </summary>
    public class Sensitivity
    {
        /// <summary>
        ///     Horizontal sensitivity value.
        ///     This value is expected to be between 1 and 10.
        /// </summary>
        private ushort _horizontal = 3;

        /// <summary>
        ///     Vertical sensitivity value.
        ///     This value is expected to be between 1 and 10.
        /// </summary>
        private ushort _vertical = 3;

        /// <summary>
        ///     Horizontal sensitivity value.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Assigned sensitivity value is less than 1 or greater than 10.
        /// </exception>
        public ushort Horizontal
        {
            get => _horizontal;
            set
            {
                if (!IsValid(value))
                    throw new ArgumentOutOfRangeException(nameof(value),
                        "Assigned sensitivity value is less than 1 or greater than 10.");

                _horizontal = value;
            }
        }

        /// <summary>
        ///     Vertical sensitivity value.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Assigned sensitivity value is less than 1 or greater than 10.
        /// </exception>
        public ushort Vertical
        {
            get => _vertical;
            set
            {
                if (!IsValid(value))
                    throw new ArgumentOutOfRangeException(nameof(value),
                        "Assigned sensitivity value is less than 1 or greater than 10.");

                _vertical = value;
            }
        }

        /// <summary>
        ///     Checks if the inbound sensitivity value falls within a valid range.
        /// </summary>
        /// <param name="value">
        ///     Inbound value to check.
        /// </param>
        /// <returns>
        ///     True on valid value, otherwise false.
        /// </returns>
        private static bool IsValid(ushort value)
        {
            return value > 1 && value < 11;
        }
    }
}