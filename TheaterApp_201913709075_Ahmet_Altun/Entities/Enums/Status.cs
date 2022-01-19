using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
