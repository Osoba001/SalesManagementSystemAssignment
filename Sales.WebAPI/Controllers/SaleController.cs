using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sale.Dome.DTO;
using Sales.Library.Model;
using Sales.Library.Services;

namespace Sales.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        Sales.Library.Model.Sale enttity = new();
        private static CreateSaleCommand cart = new();
        private readonly ISaleService _sale;
        private readonly IItemService _item;

        public SaleController(ISaleService sale,IItemService item)
        {

            _sale = sale;
            _item = item;
        }
        [HttpGet("DailySale")]
        public async Task<IActionResult> GetDailySale(DateTime day)
        {
            return Ok(await _sale.GetDailySeleItems(day));
        }
        [HttpPost("addToCart")]
        public async Task<IActionResult> PickItem(int itemId, int quantity)
        {
            var item= await _item.GetItem(itemId);
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
        public async Task<IActionResult> SellItem()
        {
            if (cart!= null)
            {
                MapCreateCommandToEntity();
                _sale.MadeSale += _item.OnMadeSale;
             return Ok( await _sale.SellItems(enttity));
            }
            return BadRequest("No item in the cart yet.");
        }

        private void MapCreateCommandToEntity()
        {
          
            enttity.TotalPrice = cart.TotalPrice;
            enttity.Items= cart.Items;
    }
    }
}
