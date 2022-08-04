using NHibernate;
using NHibernate.Linq;
using Sale.Dome.IRepositories;
using Sale.Dome.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DB.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly ISession _session;

        public BaseRepository(SessionFactory sessionFactory)
        {
            _session = sessionFactory.GetSession();
        }
        public async Task<bool> Add(T entity)
        {
            await _session.SaveAsync(entity);
            return await Commit();

        }

        public async Task<bool> Delete(T entity)
        {
           await _session.DeleteAsync(entity);
            return await Commit();
        }

        public async Task<bool> DeleteById(int id)
        {
            var ent=await _session.Query<T>().FirstOrDefaultAsync(x=>x.Id==id);
            if (ent!=null)
            {
                await _session.DeleteAsync(ent);
                return await Commit();
            }
            return false;
        }

        public IQueryable<T> GetAll()
        {
            return _session.Query<T>();
        }

        public IQueryable<T>? GetById(int id)
        {
            return _session.Query<T>().Where(x=>x.Id==id);
        }

        public async Task<bool> Update(T entity)
        {
           await _session.UpdateAsync(entity);
           return await Commit();
        }

        protected async Task<bool> Commit()
        {
            using var transction = _session.BeginTransaction();
            try
            {
                if (transction.IsActive)
                {
                    _session.Flush();
                  await  transction.CommitAsync();
                }
                return true;
            }
            catch (Exception ex)
            {
                transction.Rollback();
                return false;
            }
        }
    }
}
