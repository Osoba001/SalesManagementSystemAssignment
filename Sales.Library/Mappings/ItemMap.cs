using FluentNHibernate.Mapping;
using Sales.Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Library.Mappings
{
    public class ItemMap:ClassMap<Item>
    {
        public ItemMap()
        {
            Id(x=>x.Id);
            Map(x=>x.Name);
            Map(x=>x.Price);
            Map(x=>x.Quantity);
            
        }
    }
}
