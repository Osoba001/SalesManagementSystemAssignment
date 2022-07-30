using FluentNHibernate.Mapping;
using Sales.Library.Model;

namespace Sales.Library.Mappings
{
    public class MapSale:ClassMap<Sale>
    {
        public MapSale()
        {
            Id(x => x.Id);
            Map(x=>x.TotalPrice);
            Map(x=>x.SaleDate);
            HasMany(x=>x.Items);
        }
    }
}
