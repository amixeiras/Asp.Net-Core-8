using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Infrastructure.Data.MapEntity;
using Microsoft.Extensions.Configuration;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System.Collections;

namespace Infrastructure.Data.ConfigNhibernate
{
    public class Connection : IConnection
    {
        private ISessionFactory sessionFactory;
        private ISession session;
        private readonly IConfiguration configuration;
        public Connection(IConfiguration _configuration)
        {
            this.configuration = _configuration;
            OpenSession();
        }
        public ISession Session()
        {
            return session;
        }
        public ISessionFactory SessionFactory()
        {
            return sessionFactory;
        }


        public T Add<T>(T model)
        {
            ITransaction trans = session.BeginTransaction();
            session.Save(model);
            trans.Commit();
            session.Flush();
            return model;
        }

        public T Edit<T>(T model)
        {
            ITransaction trans = session.BeginTransaction();
            session.SaveOrUpdate(model);
            trans.Commit();
            session.Flush();
            return model;
        }

        public T Find<T>(object id)
        {
            return session.Get<T>(id);
        }

        public T Find<T>(object id, LockMode lockMode)
        {
            return session.Get<T>(id, lockMode);
        }

        public IList<T> ToList<T>()
            where T : class
        {

            return session.CreateCriteria(typeof(T))
                .List<T>();
        }
        private void OpenSession()
        {

            if (sessionFactory == null)
            {
                sessionFactory = Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql7.ConnectionString(configuration["ConnectionStrings:APP"]))
                        .Mappings(m => m.FluentMappings.Add(typeof(EnderecoMap)))
                        .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                        .BuildSessionFactory();
                session = sessionFactory.OpenSession();
            }
        }
        public void Dispose()
        {
            if (session.IsConnected)
                session.Close();
            sessionFactory.Close();
            session.Dispose();
            sessionFactory.Dispose();

        }
        public IList SqlQuery(string sql)
        {
            return session.CreateSQLQuery(sql).List();
        }
        public IQuery Query(string sql)
        {
            return session.CreateQuery(sql);
        }
        public bool Delete<T>(T model)
        {
            try
            {
                ITransaction trans = session.BeginTransaction();
                session.Delete(model);
                trans.Commit();
                session.Flush();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
