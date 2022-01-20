using System.ComponentModel;

/// <summary>
/// AppDb.json dosyasındaki her bir tiyatro nesnesinin sahip olduğu "Status" 
/// anahtarının değerlerinin bir listesini tanımlayan enum
/// </summary>
namespace TheaterApp.Entities.Enums
{
    public enum Status
    {
        [Description("Aktif")]
        Active,

        [Description("Pasif")]
        Inactive,
        
        [Description("Satışta")]
        OnSale,
        
        [Description("Satış Dışı")]
        SoldOut
    }
}
