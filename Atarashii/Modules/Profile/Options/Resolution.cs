using System;

namespace Atarashii.Modules.Profile.Options
{
    /// <summary>
    ///     Representation of the video resolution settings.
    /// </summary>
    public class Resolution
    {
        /// <summary>
        ///     Height dimension value.
        ///     This value is expected to be between 0 and 32767.
        /// </summary>
        private ushort _height = 480;

        /// <summary>
        ///     Width dimension value.
        ///     This value is expected to be between 0 and 32767.
        /// </summary>
        private ushort _width = 640;

        /// <summary>
        ///     Resolution width value.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Assigned dimension value is either 0 or over 32767.
        /// </exception>
        public ushort Width
        {
            get => _width;
            set
            {
                if (!IsValid(value))
                    throw new ArgumentOutOfRangeException(nameof(value),
                        "Assigned dimension value is either 0 or over 32767.");

                _width = value;
            }
        }

        /// <summary>
        ///     Resolution height value.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Assigned dimension value is either 0 or over 32767.
        /// </exception>
        public ushort Height
        {
            get => _height;
            set
            {
                if (!IsValid(value))
                    throw new ArgumentOutOfRangeException(nameof(value),
                        "Assigned dimension value is either 0 or over 32767.");

                _height = value;
            }
        }

        /// <summary>
        ///     Checks if the inbound dimension value falls within a valid range.
        /// </summary>
        /// <param name="value">
        ///     Inbound value to check.
        /// </param>
        /// <returns>
        ///     True on valid value, otherwise false.
        /// </returns>
        private static bool IsValid(ushort value)
        {
            return value > 0x0 && value < 0x8000;
        }
    }
}