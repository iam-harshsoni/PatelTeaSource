//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PatelTeaSource.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class order_master_payment
    {
        public long order_payment_id { get; set; }
        public Nullable<long> order_id { get; set; }
        public string payment_type { get; set; }
        public Nullable<decimal> amount { get; set; }
        public Nullable<System.DateTime> cdate { get; set; }
        public Nullable<System.DateTime> udate { get; set; }
        public Nullable<int> delete_status { get; set; }
    }
}
