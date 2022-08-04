using Sale.Dome.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale.Dome.IRepositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<bool> Add(T entity);
        IQueryable<T>? GetById(int id);
        IQueryable<T> GetAll();
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
        Task<bool> DeleteById(int id);
    }
}
