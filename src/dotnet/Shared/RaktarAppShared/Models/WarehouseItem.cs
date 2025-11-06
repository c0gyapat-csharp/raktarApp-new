using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaktarAppShared.Models
{
    public class WarehouseItem
    {
        private int _nextId = 1;
        private readonly int _id;
        private string _name;
        private int _quantity;

        public WarehouseItem() { }

        public WarehouseItem(string name, int quantity)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            if (quantity < 0)
            {
                throw new ArgumentException("Quantity cannot be negative");
            }

            _id = _nextId++;
            _name = name;
            _quantity = quantity;
        }

        [Key]
        public int Id {
            get;
            set;
        }
        public string Name {
            get => _name;
            set => _name = value;
        }

        public int Quantity {
            get => _quantity;
            set => _quantity = value;
        }


        public int SetQuantity(int quantity)
        {

            if(quantity < 0)
            {
                throw new ArgumentException("Quantity cannot be negative");
            }

            Quantity = quantity;
            return _quantity;
        }

        public void IncreaseQuantity(int amount)
        {
            if(amount < 0)
            {
                throw new ArgumentException("Amount cannot be negative");
            }
            _quantity += amount;
        }

        public void DecreaseQuantity(int amount)
        {
            if(amount < 0)
            {
                throw new ArgumentException("Amount cannot be negative");
            }
            if(_quantity - amount < 0)
            {
                throw new ArgumentException("Quantity cannot be negative");
            }
            _quantity -= amount;
        }

        public string SetName( string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            Name = name;
            return _name;
        }

        public override string ToString()
        {
            return $"Cikkszám: {_id}, {_name} - {_quantity}db";
        }

    }
}
