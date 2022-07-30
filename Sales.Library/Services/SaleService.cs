using NHibernate;
using NHibernate.Linq;
using Sales.Library.DataAccess;
using Sales.Library.Events;
using Sales.Library.Model;

namespace Sales.Library.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISession _session;
        public SaleService(IFluentNHibernateHelper helper)
        {
            _session = helper.OpenSession();
        }
        public async Task<List<Sale>> GetDailySeleItems(DateTime day)
        {
            return await _session.Query<Sale>().Where(x => x.SaleDate.Date == day.Date).ToListAsync();
        }

        public async Task<Sale> SellItems(List<Item> items)
        {
            var sale = new Sale(items);
            _session.Update(sale);
            OnMadeSales(items);
            await _session.BeginTransaction().CommitAsync();

            return sale;
        }
        protected virtual void OnMadeSales(List<Item> items)
        {
            MadeSale?.Invoke(this, new SaleEventArg() { Items = items });

        }
        public event EventHandler<SaleEventArg>? MadeSale;
    }
}
