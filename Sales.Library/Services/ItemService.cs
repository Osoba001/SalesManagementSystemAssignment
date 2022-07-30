using NHibernate;
using NHibernate.Linq;
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
        private readonly ISession _session;

        public ItemService(IFluentNHibernateHelper helper)
        {
            _session = helper.OpenSession();
        }
        public async Task AddNewItem(Item item)
        {
            _session.Save(item);
            await _session.BeginTransaction().CommitAsync();
        }

        public async Task AddToOldItem(int itemId, int quantity)
        {
            var itm=await _session.Query<Item>().FirstOrDefaultAsync(x=>x.Id==itemId);
            if (itm != null)
            {
                itm.Quantity = quantity;
                _session.Update(itm);
                await _session.BeginTransaction().CommitAsync();
            }
            else
                throw new ArgumentException("Item not found", "ItemId");
        }

        public async Task<List<Item>> GetAlltems()
        {
            return await _session.Query<Item>().ToListAsync();
        }

        public async Task<List<Item>> GetTopNItem(int n)
        {
           return await _session.Query<Item>().Take(n).ToListAsync();
        }

        public async void OnMadeSale(object? source, SaleEventArg e)
        {
            var groupItems=e.Items.GroupBy(x=>x.Id);
            foreach (var item in groupItems)
            {
                await UpdateSaleItem(item.Key, item.Count());
            }
            await _session.BeginTransaction().CommitAsync();
        }

        public async Task RemoveItem(int itemId)
        {
            var p=await _session.Query<Item>().FirstOrDefaultAsync(x=>x.Id==itemId);
            if (p is not null)
            {
                _session.Delete(p);
                await _session.BeginTransaction().CommitAsync();
            }
            else
                throw new ArgumentException("Item not found.");
            
        }

        private async Task UpdateSaleItem(int id, int quantity)
        {
            var itm = await _session.Query<Item>().FirstOrDefaultAsync(x => x.Id == id);
            if (itm != null)
            {
                itm.Quantity = -quantity;
                _session.Update(itm);
            }
            else
                throw new ArgumentException("Item not found", "ItemId");
        }

    }
}
