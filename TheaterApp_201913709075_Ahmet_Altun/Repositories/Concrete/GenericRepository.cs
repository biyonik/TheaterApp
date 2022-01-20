using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Threading.Tasks;
using TheaterApp.Entities.Abstract;
using TheaterApp.Repositories.Abstract;

namespace TheaterApp.Repositories.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity, new()
    {
        private readonly string FilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..\\..\\Data\\AppDb.json");
        private readonly JsonSerializerOptions options;
        public GenericRepository()
        {
            options = new JsonSerializerOptions();
            options.Converters.Add(new JsonStringEnumConverter());
            options.WriteIndented = true;
            options.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(UnicodeRanges.All);
        }

        public async Task AddAsync(T entity)
        {
            var allData = await GetAllAsync();
            List<T> items = new List<T>(allData);
            items.Add(entity);

            File.Delete(FilePath);
            using (FileStream fs = File.Create(FilePath))
            {
                await JsonSerializer.SerializeAsync(fs, items, options);
            }
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null)
        {
            using(FileStream fileStream = File.OpenRead(FilePath))
            { 
                var data = await JsonSerializer.DeserializeAsync<List<T>>(fileStream, options);
                if(expression != null)
                {
                    return data.AsQueryable().Where(expression).ToList();
                }
                return data;
            }
        }

        public async Task<T> GetByIdAsync(string Id)
        {
            using (FileStream fileStream = File.OpenRead(FilePath))
            {
                var collection = await JsonSerializer.DeserializeAsync<ICollection<T>>(fileStream, options);
                return (T)(from item in collection.OfType<IWithId>() where item.Id == Id select item).FirstOrDefault();
            }
        }

        public async void Remove(T entity)
        {
            var obj = (IWithId)entity;
            var data = await GetAllAsync();
            List<T> list = new List<T>(data);
            var removedItem = (T)(from x in list.OfType<IWithId>() where x.Id == obj.Id select x).SingleOrDefault();
            list.Remove(removedItem);
            File.Delete(FilePath);
            using (FileStream fs = File.Create(FilePath))
            {
                await JsonSerializer.SerializeAsync(fs, list, options);
            }
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> expression)
        {
            using (FileStream fileStream = File.OpenRead(FilePath))
            {
                var data = JsonSerializer.Deserialize<IQueryable<T>>(fileStream, options);
                var filteredData = data.Where(expression);
                return filteredData;
            }
        }
    }
}
