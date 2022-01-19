using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TheaterApp.Entities.Abstract;
using TheaterApp.Repositories.Abstract;
using TheaterApp.Repositories.Concrete;
using TheaterApp.Services.Abstract;

namespace TheaterApp.Services.Concrete
{
    public class Service<T> : IService<T> where T : class, IEntity, new()
    {
        private readonly IGenericRepository<T> _genericRepository;
        public Service()
        {
            _genericRepository = new GenericRepository<T>();
        }
        public async Task AddAsync(T entity)
        {
            await _genericRepository.AddAsync(entity);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _genericRepository.AnyAsync(expression);
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null)
        {
            return await _genericRepository.GetAllAsync(expression);
        }

        public async Task<T> GetByIdAsync(string Id)
        {
            return await _genericRepository.GetByIdAsync(Id);
        }

        public void Remove(T entity)
        {
            _genericRepository.Remove(entity);
        }

        public void Update(T entity)
        {
            _genericRepository.Update(entity);
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _genericRepository.Where(expression);
        }
    }
}
