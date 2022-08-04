using Sale.Dome.IRepositories;
using Sales.Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DB.Repositories
{
    public class ItemRepository:BaseRepository<Item>, IITemRepository
    {
        public ItemRepository(SessionFactory sessionFactory):base(sessionFactory)
        {

        }
    }
}
