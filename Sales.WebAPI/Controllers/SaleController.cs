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
        [HttpPost("MakeSale")]
        public async Task<IActionResult> SellItem(List<Item> items)
        {
            if (items != null && items.Count != 0)
            {
                _sale.MadeSale += _item.OnMadeSale;
              await  _sale.SellItems(items);
                return Ok();
            }
            return BadRequest();
        }
    }
}
