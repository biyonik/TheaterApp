using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TheaterApp.Entities.Abstract;

/// <summary>
/// Service veya Business katmanı olarak geçen katman
/// IService jenerik arayüzü IGenericRepository ile aynı metotları içerir. (Farklı da olabilirdi)
/// T tipinde jenerik bir tip alır
/// T öyle ki, T bir sınıf olmalıdır, IEntity arayüzü ile kontrat imzalamalı ve bir örneği alınabilmelidir
/// </summary>
namespace TheaterApp.Services.Abstract
{
    public interface IService<T> where T : class, IEntity, new()
    {
        /// <summary>
        /// Asenkron GetById metodu
        /// string tipinde Id adında bir parametre alır
        /// Geriye T tipinde bir nesne örneği döner
        /// Tek bir değer almak içindir
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(string Id);

        /// <summary>
        /// GetAll metodu IEnumerable arayüzü ile kontrat imzalayan bir koleksiyon sınıfından jenerik T tipinde koleksiyon sınıfı döner
        /// Parametre olarak bir linq expression alır
        /// Tüm değerleri almak içindir
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        IEnumerable<T> GetAll(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Asenkron AddAsync metodu
        /// Parametre olarak T tipinde bir varlık alır
        /// Ekleme aksiyonu içindir
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task AddAsync(T entity);

        // <summary>
        /// Update metodu
        /// Parametre olarak T tipinde bir varlık alır
        /// Güncelleme aksiyonu içindir
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// Remove metodu
        /// Parametre olarak T tipinde bir varlık alır
        /// Silme aksiyonu içindir
        /// </summary>
        /// <param name="entity"></param>
        void Remove(T entity);
    }
}
