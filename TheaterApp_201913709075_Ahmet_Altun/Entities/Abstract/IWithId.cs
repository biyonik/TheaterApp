using System;
/// <summary>
/// Somut entity ile kontrat imzalayan arayüz
/// Jeneric Repo sınıfındaki GetByIdAsync metodundaki LINQ sorgusunda filteleme yapılmak istendiğinde
/// Jenerik olarak verilen sınıf eğer bu arayüz ile kontrat imzalamış ise Id propertysi olduğu garanti olacaktır
/// Bu sayede ilgili metodun parametresi ile jenerik T entitysinin Id propertysi karşılaştırılabilir
/// Bu arayüz ile kontrat imzalayan sınıf string tipindeki Id adındaki propertyi mecburen kalıtmış olur
/// </summary>
namespace TheaterApp.Entities.Abstract
{
    public interface IWithId
    {
        string Id { get; set; }
    }
}
