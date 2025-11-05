using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaktarAppShared.Models;
namespace RaktarAppShared.Repos
{
    internal class WarehouseDtoRepo
    {
        private List<Warehouse> _warehouses = new List<Warehouse>();

        public List<Warehouse> Warehouses => _warehouses;

        public WarehouseDtoRepo() { }

        public WarehouseDtoRepo(List<Warehouse> warehouses)
        {
            _warehouses = warehouses;
        }
    }
}
