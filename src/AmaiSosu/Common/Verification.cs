/**
 * Copyright (C) 2018-2019 Emilian Roman
 * 
 * This file is part of HCE.AmaiSosu.
 * 
 * HCE.AmaiSosu is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * HCE.AmaiSosu is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with HCE.AmaiSosu.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;

namespace AmaiSosu.Common
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