﻿using Sales.Library.Events;
using Sales.Library.Model;

namespace Sales.Library.Services
{
    public interface ISaleService
    {
        Sale SellItems(List<Item> items);
        List<Sale> GetDailySeleItems(DateTime day);
        event EventHandler<SaleEventArg>? MadeSale;

    }
}