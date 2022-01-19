using TheaterApp.Entities.Abstract;

namespace TheaterApp.Entities.Concrete
{
    public class TicketPrice: IEntity
    {
        public string Level { get; set; }
        public decimal Price { get; set; }
    }
}
