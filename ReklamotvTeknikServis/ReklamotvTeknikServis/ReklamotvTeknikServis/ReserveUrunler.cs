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
    
    public partial class ReserveUrunler
    {
        public int ReseverId { get; set; }
        public Nullable<int> UrunStokId { get; set; }
        public Nullable<double> ReserveUrunAdet { get; set; }
        public Nullable<System.DateTime> ReserveTarihi { get; set; }
        public Nullable<int> ReserveYapilanFirma { get; set; }
    
        public virtual Firmalar Firmalar { get; set; }
        public virtual StoktakiUrunler StoktakiUrunler { get; set; }
    }
}
