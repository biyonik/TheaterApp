using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TheaterApp.Entities.Abstract;

namespace TheaterApp.Repositories.Abstract
{
    public interface IGenericRepository<T> where T : class, IEntity, new()
    {
        Task<T> GetByIdAsync(string Id);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression);
        IEnumerable<T> Where(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
        
    }
}
