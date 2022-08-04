using Sales.Library.Events;
using Sales.Library.Model;

namespace Sales.Library.Services
{
    public interface IItemService
    {
        Task<bool> AddNewItem(Item item);
        Task<bool> AddToOldItem(int itemId, int quantity);
        Task<List<Item>> GetTopNItem(int n);
        void OnMadeSale(object? source, SaleEventArg e);

        Task<List<Item>> GetAlltems();

        Task<bool> RemoveItem(int itemId);

        Task<Item>? GetItem(int itemId);
    }
}
