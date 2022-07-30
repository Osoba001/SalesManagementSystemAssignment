using Sales.Library.Events;
using Sales.Library.Model;

namespace Sales.Library.Services
{
    public interface IItemService
    {
        Task AddNewItem(Item item);
        Task AddToOldItem(int itemId, int quantity);
        Task<List<Item>> GetTopNItem(int n);
        void OnMadeSale(object? source, SaleEventArg e);

        Task<List<Item>> GetAlltems();

        Task RemoveItem(int itemId);
    }
}
