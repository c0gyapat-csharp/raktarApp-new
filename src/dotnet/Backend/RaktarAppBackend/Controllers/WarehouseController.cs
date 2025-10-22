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
            // Itt implementálhatod a raktár tételeinek lekérdezésének logikáját.
            return new OkObjectResult(new[] { "Item1", "Item2", "Item3" });
        }

        [HttpPost]
        public IActionResult AddItem()
        {
            // Itt implementálhatod a raktárba történő tétel hozzáadásának logikáját.
            return new OkResult();
        }

        [HttpPut]
        public IActionResult UpdateItem()
        {
            // Itt implementálhatod a raktár tételének frissítésének logikáját.
            return new OkResult();
        }

        [HttpDelete("{itemId}")]
        public IActionResult DeleteItem(int itemId)
        {
            // Itt implementálhatod a raktárból történő tétel törlésének logikáját.
            return new OkResult();
        }
    }
}
