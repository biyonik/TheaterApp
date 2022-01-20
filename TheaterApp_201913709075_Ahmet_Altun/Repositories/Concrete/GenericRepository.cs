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
    /// <summary>
    /// Jenerik Repo somut sınıf örneği
    /// IGenericRepository jenerik arayüzü ike bir kontrat imzalar
    /// Jenerik olarak T tipi alır
    /// /// T bir sınıf olmalıdır, IEntity arayüzü ile kontrat imzalamalı ve bir örneği alınabilmelidir
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity, new()
    {
        /// <summary>
        /// Dosya yolunu tutan değişken. 
        /// Sadece bu sınıfta kullanılacağı için private
        /// İçeriği değiştirilmeyeceği için readonly
        /// Mevcut proje dizinindeki Data klasöründeki AppDb.json dosyasının göreceli yolunu tutar
        /// </summary>
        private readonly string FilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..\\..\\Data\\AppDb.json");

        /// <summary>
        /// JsonSerialization sınıfının ayarlarını tutan sınıf
        /// Sys.Text.Json kütüphanesinin dahili sınıfıdır
        /// </summary>
        private readonly JsonSerializerOptions options;

        /// <summary>
        /// Yapıcı metot
        /// JsonSerializerOption sınıfının somut bir örneği alınır
        /// Status enumunun serileştirme ve deserileştirme işlemleri için Converters Ayarı yapılmış
        /// JSON'un düzgün yazdırılması için WriteIndented true atanmış
        /// Türkçe karakter için Encoder tanımı yapılmış ve UTF-8 -> UTF-16 dönüşümü için tüm unicode karakter ailesine izin verilmiş
        /// Microsoft dökümanı takip edilmesine rağmen başarılı olunamamıştır. Ekleme ve güncelleme işlemlerinde türkçe karakter kullanıldığında
        /// hata verecektir. 
        /// </summary>
        public GenericRepository()
        {
            options = new JsonSerializerOptions();
            options.Converters.Add(new JsonStringEnumConverter());
            options.WriteIndented = true;
            options.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(UnicodeRanges.All);
        }

        /// <summary>
        /// Asenkron AddAsync metodu
        /// T tipinde bir varlık alır
        /// İlk önce dosyadaki tüm değerler okunur ve bir listeye atanır
        /// Parametre olarak gelen entity bu listeye eklenir
        /// Bir FileStream nesne örneği ile Json dosyası yazma erişim yetkisi ile açılır
        /// Dosya açıldığı için başka işlem yapılmaması için thread lock ile kitlenir ve setLength ile tüm dosya içeriği silinir
        /// daha sonra yeni liste SerializeAsync metodu ile bir json içeriğine dönüştürülerek dosyayay yazılır
        /// filestream kapatılır
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task AddAsync(T entity)
        {
            var allData = GetAll();
            List<T> items = new List<T>(allData);
            items.Add(entity);
            using (FileStream fs = new FileStream(FilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                lock (fs)
                {
                    fs.SetLength(0);
                }
                await JsonSerializer.SerializeAsync(fs, items, options);
                fs.Close();
            }
        }

        /// <summary>
        /// GetAll Metodu
        /// IEnumerable arayüzü ile kontrat imzalayan bir koleksiyon döner. (T tipinde)
        /// Bir FileStream nesne örneği ile Json dosyası okuma erişim yetkisi ile açılır
        /// dynamic tipinde bir data değişkeni tanımlanır;
        /// Dosya açıldığı için başka işlem yapılmaması için thread lock ile kitlenir
        /// data değişkenine okunan json dosyası içeriği deserileştirme işlemi ile atanır. (List<T> tipinde)
        /// Eğer parametre olarak gelen expression değeri (ki bu expression arama ve filtreleme işleminde kullanılmıştır) null değil ise
        /// List<T> tipindeki data bir IQueryable tipi olarak ele alınır ve Where metodu ile expression compile edilir 
        /// ve sonuç ToList ile tekrar list tipine cast edilir ve döndürülür
        /// expression null ise data değişkeni direkt döndürülecektir
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> expression = null)
        {
            using(FileStream fileStream = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
            {
                dynamic data;
                lock(fileStream)
                {
                    data = JsonSerializer.Deserialize<List<T>>(fileStream, options);
                    if (expression != null)
                    {
                        return data.AsQueryable().Where(expression).ToList();
                    }
                    return data;
                }
            }
        }

        /// <summary>
        /// Asenkron GetByIdAsync metodu
        /// string tipinde ve Id adında bir parametre alır
        /// Bir FileStream nesne örneği ile Json dosyası okuma erişim yetkisi ile açılır
        /// collection adında bir değişkene Asenkron DeSerileştirme işlemi ile json dosya içeriği List<T> tipinde atanır
        /// fileStream kapatılır
        /// Daha sonra linq sorgusu ile koleksiyon içinde her bir item ele alınır
        /// OfType ile IWithId arayüzü veya bununla kontrat imzalayan somut sınıflardan yeni bir koleksiyon oluşturulur
        /// IWithId jenerik olan T tipinde Id propertysi olacağını garanti eder
        /// bu sayede linq sorgusunun devamında item.Id propertysi olduğunu kabul ederek parametre ile gelen Id değer ile karşılaştırır
        /// ve select ile bu itemi ele alır ve FirstOrDefault ile IWithId tipindeki entity i döner ve (T) ile T tipine cast edilir ve metottan bu nesne döner
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<T> GetByIdAsync(string Id)
        {
            using (FileStream fileStream = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
            {
                var collection = await JsonSerializer.DeserializeAsync<ICollection<T>>(fileStream, options);
                fileStream.Close();
                return (T)(from item in collection.OfType<IWithId>() where item.Id == Id select item).FirstOrDefault();
            }
        }

        /// <summary>
        /// Remove metodu
        /// T tipinde bir entity parametre alır
        /// Gelen T entitysi IWithId tipine cast edilerek bir değişkene aktarılır
        /// Dosyadaki tüm değerler GetAll ile okunur ve devamında bir listeye aktarılır
        /// GetById metodundaki linq sorgusunun aynısı burada da çalıştırılarak silinecek entity elde edilir
        /// bu entity listeden silinir
        /// Daha sonra dosya silinir
        /// FileStream nesne örneği alınır. Yeni bir dosya oluşturulacak ve yazma erişimi verilecektir
        /// Json Serialize işlemi ile liste içeriği bu yeni json dosyasına yazılır
        /// filestream kapatılır
        /// </summary>
        /// <param name="entity"></param>
        public void Remove(T entity)
        {
            var obj = (IWithId)entity;
            var data = GetAll();
            List<T> list = new List<T>(data);
            var removedItem = (T)(from x in list.OfType<IWithId>() where x.Id == obj.Id select x).SingleOrDefault();
            list.Remove(removedItem);
            File.Delete(FilePath);
            using (FileStream fs = new FileStream(FilePath, FileMode.Create, FileAccess.Write))
            {
                JsonSerializer.Serialize(fs, list, options);
                fs.Close();
            }
        }

        /// <summary>
        /// Asenkron Update metodu
        /// T tipinde bir entity alır
        /// Gelen T entitysi IWithId tipine cast edilerek bir değişkene aktarılır
        /// Dosyadaki tüm değerler GetAll ile okunur ve devamında bir listeye aktarılır
        /// GetById metodundaki linq sorgusunun aynısı burada da çalıştırılarak silinecek entity elde edilir
        /// Eski kayıt silinir ve listeye parametre olarak gelen entity eklenir. Bu entity yeni değerleri taşıyan entitydir
        /// Fakat eski entity ile yeni entitynin Id değerleri Güncelleme formunda birbirine eşitlendiği için Id değerleri aynıdır
        /// Bir FileStream nesne örneği ile Json dosyası okuma/yazma erişim yetkisi ve açma/oluşturma modunda açılır
        /// lock ile tüm processler kitlenir ve sadece filestreamin işlem yapması için tek thread e düşülür
        /// SetLength ile tüm dosya içeriği silinir
        /// lock kilidi çözüldükten sonra Asenkron Serileştirme ile yeni liste içeriği dosyaya yazılır
        /// FileStream kapatılır
        /// </summary>
        /// <param name="entity"></param>
        public async void Update(T entity)
        {
            var obj = (IWithId)entity;
            var data = GetAll();
            List<T> list = new List<T>(data);
            var removedItem = (T)(from x in list.OfType<IWithId>() where x.Id == obj.Id select x).SingleOrDefault();
            list.Remove(removedItem);
            list.Add(entity);
            using (FileStream fs = new FileStream(FilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                lock (fs)
                {
                    fs.SetLength(0);
                }
                await JsonSerializer.SerializeAsync(fs, list, options);
                fs.Close();
            }
        }
    }
}
