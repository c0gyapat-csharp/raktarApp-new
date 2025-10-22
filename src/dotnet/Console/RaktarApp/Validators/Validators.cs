using RaktarApp.Common;
using RaktarApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaktarApp.Validators
{
    internal class Validators
    {
        public static void ValidateName(string name)
        {
            if (name is null)
                throw new ValidationExceptions(ErrorMessages.NameNull);

            var trimmed = name.Trim();
            if (trimmed.Length == 0)
                throw new ValidationExceptions(ErrorMessages.NameEmpty);

            if (trimmed.Length < 2)
                throw new ValidationExceptions(ErrorMessages.NameTooShort);

            foreach (var ch in trimmed)
            {
                if (!(char.IsLetter(ch) || ch == ' ' || ch == '-'))
                    throw new ValidationExceptions(ErrorMessages.NameInvalidChars);
            }
        }

        public static void ValidateCountry(string country)
        {
            if (country is null)
                throw new ValidationExceptions(ErrorMessages.CountryNull);

            var trimmed = country.Trim();
            if (trimmed.Length == 0)
                throw new ValidationExceptions(ErrorMessages.CountryEmpty);

            if (trimmed.Length < 2)
                throw new ValidationExceptions(ErrorMessages.CountryTooShort);

            foreach (var ch in trimmed)
            {
                if (!(char.IsLetter(ch) || ch == ' ' || ch == '-'))
                    throw new ValidationExceptions(ErrorMessages.CountryInvalidChars);
            }
        }
        public static void ValidateRegion(string region)
        {
            if (region is null)
                throw new ValidationExceptions(ErrorMessages.CountryNull);

            var trimmed = region.Trim();
            if (trimmed.Length == 0)
                throw new ValidationExceptions(ErrorMessages.CountryEmpty);

            if (trimmed.Length < 2)
                throw new ValidationExceptions(ErrorMessages.CountryTooShort);
        }

        public static void ValidatePostCode(int postCode)
        {
            if (postCode <= 0)
                throw new ValidationExceptions(ErrorMessages.PostCodeInvalid);
        }

        public static void ValidateCity(string city)
        {
            if (city is null)
                throw new ValidationExceptions(ErrorMessages.NameNull);
            var trimmed = city.Trim();
            if (trimmed.Length == 0)
                throw new ValidationExceptions(ErrorMessages.NameEmpty);
        }

        public static void ValidateAddress(string address)
        {
            if (address is null)
                throw new ValidationExceptions(ErrorMessages.NameNull);
            var trimmed = address.Trim();
            if (trimmed.Length == 0)
                throw new ValidationExceptions(ErrorMessages.NameEmpty);
        }
    }
}
