using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaktarApp.Common
{
    internal class ErrorMessages
    {
        public const string ObjectNull = "Az ellenőrzött objektum nem lehet null.";
        public const string NameNull = "A név nem lehet null.";
        public const string NameEmpty = "A név nem lehet üres.";
        public const string NameTooShort = "A név legalább 2 karakter legyen.";
        public const string NameInvalidChars = "A név csak betűket, szóközt és kötőjelet tartalmazhat.";
        public const string CountryNull = "Az ország nem lehet null.";
        public const string CountryEmpty = "Az ország nem lehet üres.";
        public const string CountryTooShort = "Az ország legalább 2 karakter legyen.";
        public const string CountryInvalidChars = "Az ország csak betűket, szóközt és kötőjelet tartalmazhat.";
        public const string RegionNull = "A régió nem lehet null.";
        public const string RegionEmpty = "A régió nem lehet üres.";
        public const string RegionTooShort = "A régió legalább 2 karakter legyen.";
        public const string RegionInvalidChars = "A régió csak betűket, szóközt és kötőjelet tartalmazhat.";
        public const string PostCodeInvalid = "Az irányítószám érvénytelen.";

    }
}
