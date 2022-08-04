using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sales.Library.Model;
using Sales.Library.Services;

namespace Sales.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private static Sale cart = new Sale();
        private readonly ISaleService _sale;
        private readonly IItemService _item;

        public SaleController(ISaleService sale,IItemService item)
        {

            _sale = sale;
            _item = item;
        }
        [HttpGet("DailySale")]
        public IActionResult GetDailySale(DateTime day)
        {
            return Ok(_sale.GetDailySeleItems(day));
        }
        [HttpPost("addToCart")]
        public IActionResult PickItem(int itemId, int quantity)
        {
            var item=_item.GetItem(itemId);
            if (item!=null)
            {
                for (int i = 0; i < quantity; i++)
                {
                    
                    cart.Items.Add(item);
                }
                return Ok(cart);
            }else
                return BadRequest("Item with the given Id is not found.");
        }

        [HttpPost("makeSale")]
        public IActionResult SellItem()
        {
            if (cart!= null)
            {
                _sale.MadeSale += _item.OnMadeSale;
             return Ok(_sale.SellItems(cart));
            }
            return BadRequest();
        }
    }
}
