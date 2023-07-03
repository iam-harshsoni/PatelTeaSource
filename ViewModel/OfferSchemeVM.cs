using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatelTeaSource.ViewModel
{
    public class OfferSchemeVM
    {
        public long offerId { get; set; }
        public string passedScheme { get; set; }
        public string upcoming { get; set; }
        public Nullable<long> pId { get; set; }
        public Nullable<System.DateTime> cDate { get; set; }
        public Nullable<System.DateTime> uDate { get; set; }

        public virtual ProductMasterVM product_master { get; set; }
    }
}