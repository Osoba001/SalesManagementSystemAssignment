using Sale.Dome.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DB.Repositories
{
    public class SaleRepository:BaseRepository<Sales.Library.Model.Sale>, ISaleRepository
    {
        public SaleRepository(SessionFactory sessionFactory):base(sessionFactory)
        {

        }
    }
}
