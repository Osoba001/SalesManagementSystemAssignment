using NHibernate;
using NHibernate.Linq;
using Sale.Dome.IRepositories;
using Sales.Library.DataAccess;
using Sales.Library.Events;
using Sales.Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Library.Services
{
    public class ItemService : IItemService
    {
        private readonly IITemRepository _itemRepo;

        public ItemService(IITemRepository itemRepo)
        {
            _itemRepo = itemRepo;
        }
        public async Task<bool> AddNewItem(Item item)
        {
         return  await _itemRepo.Add(item);
        }

        public async Task<bool> AddToOldItem(int itemId, int quantity)
        {
            var item= _itemRepo.GetById(itemId).FirstOrDefault();
            if (item!=null)
            {
                item.Quantity = quantity;
              return await  _itemRepo.Update(item);
            }
            throw new ArgumentException("Item with the given Id not found");
        }

        public async Task<List<Item>> GetAlltems()
        {
            return await _itemRepo.GetAll().ToListAsync();
        }

        public async Task<Item>? GetItem(int itemId)
        {
            return await _itemRepo.GetById(itemId).FirstOrDefaultAsync();
        }

        public async Task<List<Item>> GetTopNItem(int n)
        {
            return await _itemRepo.GetAll().Take(n).ToListAsync();

        }

        public async void OnMadeSale(object? source, SaleEventArg e)
        {
            var groupItems=e.Items.GroupBy(x=>x.Id);
            foreach (var item in groupItems)
            {
              await AddToOldItem(item.Key, -item.Count());
            }
        }

        public async Task<bool> RemoveItem(int itemId)
        {
            return await _itemRepo.DeleteById(itemId);
        }

    }
}
