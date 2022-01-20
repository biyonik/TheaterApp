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
    /// <summary>
    /// Jenerik Service somut sınıf örneği
    /// IService jenerik arayüzü ike bir kontrat imzalar
    /// Jenerik olarak T tipi alır
    /// /// T bir sınıf olmalıdır, IEntity arayüzü ile kontrat imzalamalı ve bir örneği alınabilmelidir
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Service<T> : IService<T> where T : class, IEntity, new()
    {
        /// <summary>
        /// IGenericRepository jenerik arayüzünde bir değişken
        /// Yapıcı metotta somut GenericRepository sınıfı ile bir örneği alınmıştır
        /// </summary>
        private readonly IGenericRepository<T> _genericRepository;
        public Service()
        {
            _genericRepository = new GenericRepository<T>();
        }

        /// <summary>
        /// Asenkron Add metodu
        /// T tipinde bir entity alır
        /// Jenerik Repository sınıfındaki AddAsync metodunu kotarır
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task AddAsync(T entity)
        {
            await _genericRepository.AddAsync(entity);
        }

        /// <summary>
        /// GetAll metodu
        /// IEnumerable arayüzü ile kontrat imzalayan jenerik bir T tipinde koleksiyon döner
        /// Linq expression için bir expression parametre alır
        /// JenerikRepository sınıfındaki GetAll metodunu kotarır
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> expression = null)
        {
            return _genericRepository.GetAll(expression);
        }

        /// <summary>
        /// Asenkron GetByIdAsync metodu
        /// T tipinde bir nesne döner
        /// String tipinde bir parametre alır
        /// Jenerik Repository sınıfındaki GetByIdAsync metodunu kotarır
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<T> GetByIdAsync(string Id)
        {
            return await _genericRepository.GetByIdAsync(Id);
        }

        /// <summary>
        /// Remove metodu
        /// T tipinde bir entity alır
        /// Jenerik Repository sınıfındaki Remove metodunu çağırır
        /// </summary>
        /// <param name="entity"></param>
        public void Remove(T entity)
        {
            _genericRepository.Remove(entity);
        }

        /// <summary>
        /// Update metodu
        /// T tipinde bir entity alır
        /// Jenerik Repository sınıfındaki Update metodunu kotarır
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            _genericRepository.Update(entity);
        }
    }
}
