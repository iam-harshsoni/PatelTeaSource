using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatelTeaSource.ViewModel
{
    public class ProductMasterVM
    {
        public long p_id { get; set; }
        public string pname { get; set; }
        public string photo { get; set; }
        public string description { get; set; }
        public Nullable<int> weight { get; set; }
        public string unit { get; set; }
        public string nutritionImg { get; set; }
        public Nullable<System.DateTime> cDate { get; set; }
        public Nullable<System.DateTime> uDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OfferSchemeVM> offerSchemes { get; set; }

      
    }
}