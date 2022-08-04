using NHibernate;
using NHibernate.Linq;
using Sale.Dome.IRepositories;
using Sales.Library.DataAccess;
using Sales.Library.Events;
using Sales.Library.Model;

namespace Sales.Library.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepo;

        public SaleService(ISaleRepository saleRepo)
        {
            _saleRepo = saleRepo;
        }
        public async Task<List<Sales.Library.Model.Sale>> GetDailySeleItems(DateTime day)
        {
            return await _saleRepo.GetAll().Where(x => x.SaleDate.Date == day.Date).ToListAsync();
        }

        public async Task<Sales.Library.Model.Sale> SellItems(Sales.Library.Model.Sale sale)
        {
           await _saleRepo.Add(sale);
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
