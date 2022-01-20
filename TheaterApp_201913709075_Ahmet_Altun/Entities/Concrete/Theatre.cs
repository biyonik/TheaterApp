using System;
using System.Collections.Generic;
using System.ComponentModel;
using TheaterApp.Entities.Abstract;
using TheaterApp.Entities.Enums;

/// <summary>
/// Theatre somut sınıfı
/// IEntity arayüzü ile ve IWithId arayüzü ile kontrat imzalar
/// IWithId arayüzü ile kontrat imzaladığı için string türündeki Id propertysi mecburent bulunmak zorundadır
/// AppDb.json dosyasındaki key isimlerine karşılık doğru tip ve adda propertyler barındırır
/// Attribut aracılığı ile her property için görünür bir isim verilmiştir.
/// </summary>
namespace TheaterApp.Entities.Concrete
{
    public class Theatre: IEntity, IWithId
    {
        public string Id { get; set; }
        [DisplayName("Durum")]
        public Status Status { get; set; }
        [DisplayName("Başlık")]
        public string Title { get; set; }
        [DisplayName("Tarih")]
        public DateTime Date { get; set; }
        [DisplayName("Saat")]
        public string Time { get; set; }
        [DisplayName("Tiyato")]
        public string Theater { get; set; }
        [DisplayName("Sahne")]
        public string Scene { get; set; }
        [DisplayName("Şehir")]
        public string City { get; set; }
        [DisplayName("Yazan")]
        public string Writer { get; set; }
        [DisplayName("Çeviren")]
        public string Translater { get; set; }
        [DisplayName("Uyarlayan")]
        public string AdaptedBy { get; set; }
        [DisplayName("Yöneten")]
        public string DirectedBy { get; set; }
        [DisplayName("Açıklama")]
        public string Description { get; set; }
        [DisplayName("Kurallar")]
        public ICollection<string> ActivityRules { get; set; } = new List<string>();
        [DisplayName("Bilet Fiyatları")]
        public ICollection<TicketPrice> TicketPrices { get; set; } = new HashSet<TicketPrice>();

        public override string ToString()
        {
            return this.Title;
        }
    }
}
