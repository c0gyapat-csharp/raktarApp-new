using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaktarApp.Models;

namespace RaktarApp.Repos
{
    internal class WarehouseRepo
    {

        List<Warehouse> _warehouses = new List<Warehouse>();


        public List<Warehouse> Warehouses => _warehouses;

        public WarehouseRepo() { }

        public WarehouseRepo(List<Warehouse> warehouses)
        {
            _warehouses = warehouses;
        }

        public List<Warehouse> GetAllWarehouses()
        {
            return _warehouses;
        }

        public void RemoveWarehouse(int id)
        {
            Warehouse? warehouse = _warehouses.FirstOrDefault(w => w.Id == id);
            if (warehouse != null)
            {
                if(warehouse.CanDelete())
                {
                    _warehouses.Remove(warehouse);
                }
                else
                {
                    throw new InvalidOperationException("Warehouse cannot be deleted because it contains items");
                }
            }
            else
            {
                throw new ArgumentException("Warehouse not found");
            }
        }

        public void AddWarehouse(Warehouse warehouse)
        {
            if(warehouse == null)
            {
                throw new ArgumentException("Warehouse cannot be null");
            }
            if(_warehouses.Contains(warehouse))
            {
                throw new ArgumentException("Warehouse already exists");
            }
            _warehouses.Add(warehouse);
        }


        public void AddDtoWarehouse(Warehouse warehouse)
        {
            _warehouses.Add(warehouse);
        }
    }
}
