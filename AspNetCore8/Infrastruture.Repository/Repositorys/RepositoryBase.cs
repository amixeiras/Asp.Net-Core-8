using Domain.Core.Interfaces.Repository;
using Infrastructure.Data.ConfigNhibernate;
using Microsoft.Extensions.Configuration;

namespace Infrastruture.Repository.Repositorys
{
    public abstract class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly IConfiguration configuration;

        public RepositoryBase(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public virtual void Add(TEntity obj)
        {
            try
            {
                using (IConnection db = new Connection(configuration))
                {
                    db.Add<TEntity>(obj);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao incluir dados", ex);
            }
        }

        public virtual TEntity GetById(int id)
        {
            using (IConnection db = new Connection(configuration))
                return db.Find<TEntity>(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            using (IConnection db = new Connection(configuration))
                return db.ToList<TEntity>();
        }

        public virtual void Update(TEntity obj)
        {
            try
            {
                using (IConnection db = new Connection(configuration))
                    db.Edit<TEntity>(obj);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar registro", ex);
            }
        }

        public virtual void Remove(TEntity obj)
        {
            try
            {
                using (IConnection db = new Connection(configuration))
                    db.Delete<TEntity>(obj);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao remover registro", ex);
            }
        }

        public virtual void Dispose()
        {
            using (IConnection db = new Connection(configuration))
                db.Dispose();
        }


    }
}
