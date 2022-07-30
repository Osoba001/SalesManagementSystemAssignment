using NHibernate;

namespace Sales.Library.DataAccess
{
    public interface IFluentNHibernateHelper
    {
        ISessionFactory SessionFactory { get; }

        ISession OpenSession();
    }
}