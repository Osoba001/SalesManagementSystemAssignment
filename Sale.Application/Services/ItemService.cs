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
        public static List<Item> items = new();

        public void AddNewItem(Item item)
        {
            int index=0;
            if (items.Count>0)
            {
                index = items.Last().Id+1;
            }
            item.Id = index;
            items.Add(item);
           
        }

        public void AddToOldItem(int itemId, int quantity)
        {
            var item=items.FirstOrDefault(x=>x.Id==itemId);
            if (item!=null)
            {
                item.Quantity = quantity;
            }
        }

        public List<Item> GetAlltems()
        {
            return items;
        }

        public Item GetItem(int itemId)
        {
            return items.FirstOrDefault(x => x.Id == itemId);
        }

        public List<Item> GetTopNItem(int n)
        {
            return items.Take(n).ToList();
           
        }

        public void OnMadeSale(object? source, SaleEventArg e)
        {
            var groupItems=e.Items.GroupBy(x=>x.Id);
            foreach (var item in groupItems)
            {
                 UpdateSaleItem(item.Key, item.Count());
            }
        }

        public void RemoveItem(int itemId)
        {
            var p=items.FirstOrDefault(x=>x.Id==itemId);
            if (p is not null)
            {
               items.Remove(p);
            }
            else
                throw new ArgumentException("Item not found.");
            
        }

        private void UpdateSaleItem(int id, int quantity)
        {
            var itm = items.FirstOrDefault(x => x.Id == id);
            if (itm != null)
            {
                itm.Quantity = -quantity;
            }
            else
                throw new ArgumentException("Item not found", "ItemId");
        }

    }
}
