using Sales.Library.Events;
using Sales.Library.Model;

namespace Sales.Library.Services
{
    public interface IItemService
    {
        void AddNewItem(Item item);
        void AddToOldItem(int itemId, int quantity);
        List<Item> GetTopNItem(int n);
        void OnMadeSale(object? source, SaleEventArg e);

        List<Item> GetAlltems();

        void RemoveItem(int itemId);

        Item GetItem(int itemId);
    }
}
