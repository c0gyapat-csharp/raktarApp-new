using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaktarAppBackend.Context;


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
        public IActionResult AddItem()
        {
            return new OkResult();
        }

        [HttpPut]
        public IActionResult UpdateItem()
        {
            return new OkResult();
        }

        [HttpDelete("{itemId}")]
        public IActionResult DeleteItem(int itemId)
        {
            return new OkResult();
        }
    }
}
