using Sales.Library.Events;
using Sales.Library.Model;

namespace Sales.Library.Services
{
    public interface ISaleService
    {
        Task<Sales.Library.Model.Sale> SellItems(Sales.Library.Model.Sale items);
        Task<List<Sales.Library.Model.Sale>> GetDailySeleItems(DateTime day);
        event EventHandler<SaleEventArg>? MadeSale;

    }
}
