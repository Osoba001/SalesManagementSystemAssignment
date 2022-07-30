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
        public async Task<IActionResult> GetTopNItems(int n)
        {
            return Ok(await _item.GetTopNItem(n));
        }
        [HttpPost]
        public async Task<IActionResult> AddItem([FromBody] Item item)
        {
           await _item.AddNewItem(item);
            return Ok();
        }
        [HttpPut("AddToOldItem")]
        public async Task<IActionResult> AddToItem(int ItemId, int quantity)
        {
            await _item.AddToOldItem(ItemId, quantity);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _item.GetAlltems());
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteItem(int ItemId)
        {
            await _item.RemoveItem(ItemId);
            return Ok();
        }
    }
}
