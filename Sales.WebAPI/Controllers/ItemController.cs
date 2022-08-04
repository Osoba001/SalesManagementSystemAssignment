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
        [HttpGet("getTopN")]
        public async Task<IActionResult> GetTopNItems(int n)
        {
            return Ok( await _item.GetTopNItem(n));
        }
        [HttpPost]
        public async Task<IActionResult> AddItem([FromBody] Item item)
        {
            return Ok(await _item.AddNewItem(item));
           
        }
        [HttpPut("updateItemQuantity")]
        public async Task<IActionResult> AddToItem(int ItemId, int quantity)
        {
            return Ok(await _item.AddToOldItem(ItemId, quantity));
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _item.GetAlltems());
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteItem(int ItemId)
        {
             return Ok(await _item.RemoveItem(ItemId));
           
        }
    }
}
