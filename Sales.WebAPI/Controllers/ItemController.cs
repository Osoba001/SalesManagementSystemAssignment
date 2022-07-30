using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sales.Library.Model;
using Sales.Library.Services;

namespace Sales.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _item;

        public ItemController(IItemService item)
        {
            _item = item;
        }
        [HttpGet("GetTopN")]
        public IActionResult GetTopNItems(int n)
        {
            return Ok(_item.GetTopNItem(n));
        }
        [HttpPost]
        public IActionResult AddItem([FromBody] Item item)
        {
            _item.AddNewItem(item);
            return Ok();
        }
        [HttpPut("AddToOldItem")]
        public IActionResult AddToItem(int ItemId, int quantity)
        {
            _item.AddToOldItem(ItemId, quantity);
            return Ok();
        }
    }
}
