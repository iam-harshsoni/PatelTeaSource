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
    
    public partial class offerScheme
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public offerScheme()
        {
            this.order_history = new HashSet<order_history>();
        }
    
        public long offerId { get; set; }
        public string passedScheme { get; set; }
        public string upcoming { get; set; }
        public Nullable<long> pId { get; set; }
        public Nullable<System.DateTime> cDate { get; set; }
        public Nullable<System.DateTime> uDate { get; set; }
        public string offer_type { get; set; }
    
        public virtual product_master product_master { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order_history> order_history { get; set; }
    }
}
