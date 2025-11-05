using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaktarAppBackend.Context;
using RaktarAppShared.Models;


namespace RaktarAppBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WarehouseController
    {

        AppSqliteDbContext _dbContext = new AppSqliteDbContext();

        [HttpGet]
        public IActionResult GetItems()
        {
            var items = _dbContext.Warehouses.ToList();
            
            return new OkObjectResult(new { items });
        }

        [HttpGet("{itemId}")]
        public IActionResult GetItemById(int itemId)
        {
            var item = _dbContext.Warehouses.FirstOrDefault(i => i.Id == itemId);
            return new OkObjectResult(new { item });
        }

        [HttpGet("count")]
        public IActionResult GetItemCount()
        {
            var count = _dbContext.Warehouses.Count();

            return new OkObjectResult(new { count });
        }

        [HttpPost]
        public IActionResult AddItem([FromBody] Warehouse warehouse)
        {
            if(warehouse  == null)
            {
                return new BadRequestObjectResult(new { error = "Request body must be a valid Warehouse object." }); 
            }

            warehouse.Id = _dbContext.Warehouses.OrderBy(w => w.Id).Last().Id + 1;

            _dbContext.Warehouses.Add(warehouse);
            _dbContext.SaveChanges();

            return new OkObjectResult(warehouse);
        }

        [HttpPost("sync")]
        public IActionResult AddBulk([FromBody] List<Warehouse> items)
        {
            if (items == null || !items.Any())
                return new BadRequestObjectResult(new { error = "Request body must be a JSON array of Warehouse objects." });

            _dbContext.Warehouses.RemoveRange(_dbContext.Warehouses);
            _dbContext.Warehouses.AddRange(items);
            _dbContext.SaveChanges();

            return new OkObjectResult(new { added = items.Count });
        }

        [HttpPut]
        public IActionResult UpdateItem([FromBody] Warehouse warehouse)
        {
            if (warehouse == null)
            {
                return new BadRequestObjectResult(new { error = "Request body must be a valid Warehouse object." });
            }

            _dbContext.Warehouses.Update(warehouse);
            _dbContext.SaveChanges();

            return new OkObjectResult(warehouse);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            var result = _dbContext.Warehouses.Remove(new Warehouse { Id = id });
            _dbContext.SaveChangesAsync();

            return new OkResult();
        }
    }
}
