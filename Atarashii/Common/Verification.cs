using System;

namespace Atarashii.Common
{
    public class Verification
    {
        public Verification(bool isValid)
        {
            IsValid = isValid;
        }

        public Verification(bool isValid, string reason) : this(isValid)
        {
            if (!isValid && string.IsNullOrWhiteSpace(reason))
                throw new ArgumentException("Please provide a reason for the false isValid status.");

            Reason = reason;
        }

        public bool IsValid { get; }
        public string Reason { get; }
    }
}