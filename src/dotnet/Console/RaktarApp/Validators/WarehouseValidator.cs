using RaktarApp.Common;
using RaktarApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaktarApp.Validators
{
    internal class WarehouseValidator
    {
        public static void Validate(WarehouseDto warehouse)
        {
            if (warehouse == null)
                throw new ValidationException(ErrorMessages.ObjectNull);

            Validate(warehouse.Name, warehouse.Country, warehouse.Region, warehouse.PostCode, warehouse.City, warehouse.Address);
        }

        public static void Validate(string name, string country, string region, int postCode, string city, string address)
        {
            Validators.ValidateName(name);
            Validators.ValidateCountry(country);
            Validators.ValidateRegion(region);
            Validators.ValidatePostCode(postCode);
            Validators.ValidateCity(city);
            Validators.ValidateAddress(address);
        }
    }
}
