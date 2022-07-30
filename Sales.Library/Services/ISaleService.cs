using Sales.Library.Events;
using Sales.Library.Model;

namespace Sales.Library.Services
{
    public interface ISaleService
    {
        Task<Sale> SellItems(List<Item> items);
        Task<List<Sale>> GetDailySeleItems(DateTime day);
        event EventHandler<SaleEventArg>? MadeSale;

    }
}
