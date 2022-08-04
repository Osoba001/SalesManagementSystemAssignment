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

namespace Sales.DB
{
    public class SessionFactory
    {
        public SessionFactory(string connectionString)
        {
            _connectionString = connectionString;
            if (_sessionFactory is null)
            {
                _sessionFactory = BuildSessionFactory(_connectionString);
            }
        }

        public ISession GetSession() => _sessionFactory.OpenSession();

        private readonly ISessionFactory _sessionFactory;
        private readonly string _connectionString;

        private ISessionFactory BuildSessionFactory(string connectionString)
        {
            FluentConfiguration configuration = Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.ConnectionString(connectionString))
                .Mappings(m => m.FluentMappings.AddFromAssembly(typeof(MapSale).Assembly))
                .ExposeConfiguration(cfg =>
                {
                    new SchemaUpdate(cfg).Execute(true, true);
                });
            return configuration.BuildSessionFactory();
        }

        //private readonly string _connecttionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\Users\\Murphy\\Documents\\Backup\\Documents\\Software Academy\\CCSA_Web\\NotesAppDB.mdf;Integrated Security=True;Connect Timeout=30";
        
    }
}
