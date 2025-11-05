using RaktarApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaktarApp.Repos
{
    internal class WarehouseDtoRepo
    {

        private List<WarehouseDto> _warehouses = new List<WarehouseDto>();

        public List<WarehouseDto> Warehouses => _warehouses;

        public WarehouseDtoRepo() { }

        public WarehouseDtoRepo(List<WarehouseDto> warehouses)
        {
            _warehouses = warehouses;
        }
        public void CsvToDto(WarehouseCsv warehouseCsv)
        {

            int id = int.Parse(warehouseCsv.Id);
            string name = warehouseCsv.Name;
            string country = warehouseCsv.Country;
            string region = warehouseCsv.Region;
            int postCode = int.Parse(warehouseCsv.PostCode);
            string city = warehouseCsv.City;
            string address = warehouseCsv.Address;

            WarehouseDto warehouseDto = new WarehouseDto(
                id,
                name,
                country,
                region,
                postCode,
                city,
                address
            );

            try
            {
                Validators.WarehouseValidator.Validate(warehouseDto);

                _warehouses.Add(warehouseDto);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Invalid WarehouseDto data: {ex.Message}");
            }
        }

        public void SyncToDB()
        {
            HttpClient client = new HttpClient();

            var warehousesJson = System.Text.Json.JsonSerializer.Serialize(_warehouses);

            var content = new StringContent(warehousesJson, Encoding.UTF8, "application/json");

            var response = client.PostAsync("https://localhost:7019/Warehouse/bulk", content).Result;

            Console.WriteLine(response);
        }
    }
}
