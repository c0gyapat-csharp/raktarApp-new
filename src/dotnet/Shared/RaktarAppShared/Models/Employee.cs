using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaktarApp.Models
{
    public class Employee
    {

        private int _nextId = 1;
        private readonly int _id;
        private string _name;
        private string _position;
        private int _warehouseId;

        public Employee() { }
        public Employee(string name, string position, int warehouseId)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            if (string.IsNullOrWhiteSpace(position))
            {
                throw new ArgumentException("Position cannot be empty");
            }
            if (warehouseId < 0)
            {
                throw new ArgumentException("Warehouse ID cannot be negative");
            }
            _id = _nextId++;
            _name = name;
            _position = position;
            _warehouseId = warehouseId;
        }



        public override string ToString()
        {
            return $"ID: {_id}, Name: {_name}, Position: {_position}, Warehouse ID: {_warehouseId}";
        }
    }
}
