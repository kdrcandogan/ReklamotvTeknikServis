//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ReklamotvTeknikServis
{
    using System;
    using System.Collections.Generic;
    
    public partial class BirlestirilenUrun
    {
        public int BirlestirilenUrunId { get; set; }
        public string BirlestirilenUrunAdi { get; set; }
        public string BirlestirilenUrunParcalari { get; set; }
        public Nullable<System.DateTime> UrunOlusturmaTarihi { get; set; }
        public Nullable<int> UrunStokId { get; set; }
    
        public virtual StoktakiUrunler StoktakiUrunler { get; set; }
    }
}
