﻿using NHibernate;
using NHibernate.Linq;
using Sales.Library.DataAccess;
using Sales.Library.Events;
using Sales.Library.Model;

namespace Sales.Library.Services
{
    public class SaleService : ISaleService
    {
        public static List<Sale> sales = new();

        public List<Sale> GetDailySeleItems(DateTime day)
        {
            return sales.Where(x => x.SaleDate.Date == day.Date).ToList();
        }

        public Sale SellItems(Sale sale)
        {
            int index = 0;
            if (sales.Count > 0)
            {
                index = sales.Last().Id + 1;
            }
            sale.Id = index;
            sales.Add(sale);
            OnMadeSales(sale.Items);
            return sale;
        }
        protected virtual void OnMadeSales(List<Item> items)
        {
            MadeSale?.Invoke(this, new SaleEventArg() { Items = items });
        }
        public event EventHandler<SaleEventArg>? MadeSale;
    }
}
