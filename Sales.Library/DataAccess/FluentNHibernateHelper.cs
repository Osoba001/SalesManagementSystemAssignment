using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Sales.Library.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Library.DataAccess
{
    public class FluentNHibernateHelper : IFluentNHibernateHelper
    {
        public FluentNHibernateHelper(string connectionString)
        {
            _connectionString = connectionString;
        }
        private ISessionFactory? _sessionFactory;

        public ISessionFactory SessionFactory => _sessionFactory ??
            Fluently.Configure().Database(SQLiteConfiguration.Standard.ConnectionString(_connectionString))
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ItemMap>())
            .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true))
            .BuildSessionFactory();

        public ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
        private readonly string _connectionString;
    }
}

