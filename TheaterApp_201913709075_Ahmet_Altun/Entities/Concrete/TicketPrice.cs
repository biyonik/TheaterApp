using TheaterApp.Entities.Abstract;

/// <summary>
/// TicketPrice somut sınıfı
/// IEntity arayüzü ile kontrat imzalar
/// AppDb.json dosyasındaki her bir tiyatro için "TicketPrices" dizisinin tek bir elemanına denk gelir
/// </summary>
namespace TheaterApp.Entities.Concrete
{
    public class TicketPrice: IEntity
    {
        public string Level { get; set; }
        public decimal Price { get; set; }
    }
}
