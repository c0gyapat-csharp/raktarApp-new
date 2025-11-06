using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaktarAppShared.Models
{
    public class Warehouse
    {
        private int _nextId = 1;

        private readonly int _id;

        private string _name;

        private readonly string _country;

        private readonly string _region;

        private readonly int _postCode;

        private readonly string _city;

        private readonly string _address;

        private List<WarehouseItem> _items = new List<WarehouseItem>();

        public Warehouse() { }
        public Warehouse(string name, Dictionary<string, string> address)
        {

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be empty");
            }


            if (!address.ContainsKey("address") || !address.ContainsKey("city") || !address.ContainsKey("postCode") || !address.ContainsKey("region") || !address.ContainsKey("country"))
            {
                throw new ArgumentException("Address must contain country, region, postCode, city, address");

            }

            _id = _nextId++;
            _name = name;
            _address = address["address"];
            _city = address["city"];
            _postCode = int.Parse(address["postCode"]);
            _region = address["region"];
            _country = address["country"];
        }
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public string Region { get; set; }

        public int PostCode { get; set; }

        public string City { get; set; }

        public string Address { get; set; }
        public string FullAddress
        {
            get => $"{Country} {Region} {PostCode} {City} {Address}";
        }
        public ICollection<WarehouseItem> Items { get; set; } = new List<WarehouseItem>();


        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            Name = name;
        }

        public void AddItem(WarehouseItem item)
        {
            if (item == null)
            {
                throw new ArgumentException("Item cannot be null");
            }

            if (_items.Contains(item))
            {
                throw new ArgumentException("Item already exists in the warehouse");
            }

            _items.Add(item);
        }

        public void RemoveItem(WarehouseItem item)
        {
            if (item == null)
            {
                throw new ArgumentException("Item cannot be null");
            }
            if (!_items.Contains(item))
            {
                throw new ArgumentException("Item does not exist in the warehouse");
            }

            if (_items.Find(i => i.Id == item.Id)?.Quantity != 0)
            {
                throw new InvalidOperationException("Item quantity must be zero to remove it from the warehouse");
            }

            _items.Remove(item);
        }

        public bool CanDelete()
        {
            return _items.Count == 0;
        }

        public override string ToString()
        {
            return $"Warehouse ID: {_id}, Name: {_name}, Address: {_country} {_region} {_postCode} {_city} {_address}";
        }


    }
}
