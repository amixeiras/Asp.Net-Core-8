using NHibernate;
using System.Collections;

namespace Infrastructure.Data.ConfigNhibernate
{
    public interface IConnection : IDisposable
    {
        T Add<T>(T model);
        T Edit<T>(T model);
        T Find<T>(object id);
        T Find<T>(object id, LockMode lockMode);
        IList<T> ToList<T>() where T : class;
        ISession Session();
        ISessionFactory SessionFactory();
        IList SqlQuery(string sql);
        IQuery Query(string sql);
        bool Delete<T>(T model);
    }
}
