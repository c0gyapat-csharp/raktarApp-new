using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaktarAppShared.Models
{
    public class Warehouse
    {
        private readonly int _id;
        private readonly string _name;
        private readonly string _country;
        private readonly string _region;
        private readonly int _postCode;
        private readonly string _city;
        private readonly string _address;

		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public string Country { get; set; } = null!;
		public string Region { get; set; } = null!;
		public int PostCode { get; set; }
		public string City { get; set; } = null!;
		public string Address { get; set; } = null!;

        public Warehouse() { }
        public Warehouse(int id, string name, string country, string region, int postCode, string city, string address)
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
