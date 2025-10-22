using Microsoft.AspNetCore.Mvc;

namespace RaktarAppBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WarehouseController
    {
        [HttpGet]
        public IActionResult GetItems()
        {
            return new OkObjectResult(new[] { "Item1", "Item2", "Item3" });
        }

        [HttpGet("count")]
        public IActionResult GetItemCount()
        {
            return new OkObjectResult(new { count = 3 });
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
