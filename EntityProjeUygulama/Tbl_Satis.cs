//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityProjeUygulama
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_Satis
    {
        public int SATISID { get; set; }
        public Nullable<int> URUN { get; set; }
        public Nullable<int> MUSTERİ { get; set; }
        public Nullable<decimal> FİYAT { get; set; }
        public Nullable<System.DateTime> TARİH { get; set; }
    
        public virtual Tbl_Musteri Tbl_Musteri { get; set; }
        public virtual Tbl_Urun Tbl_Urun { get; set; }
    }
}
