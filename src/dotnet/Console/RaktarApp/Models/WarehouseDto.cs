using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaktarApp.Models
{
    internal class WarehouseDto: Warehouse
    {
        private readonly int _id;
        private readonly string _name;
        private readonly string _country;
        private readonly string _region;
        private readonly int _postCode;
        private readonly string _city;
        private readonly string _address;

        public int Id => _id;
        public string Name => _name;
        public string Country => _country;
        public string Region => _region;
        public int PostCode => _postCode;
        public string City => _city;
        public string Address => _address;

        public WarehouseDto() { }
        public WarehouseDto(int id, string name, string country, string region, int postCode, string city, string address)
        {
            _id = id;
            _name = name;
            _country = country;
            _region = region;
            _postCode = postCode;
            _city = city;
            _address = address;
        }

    }
}
