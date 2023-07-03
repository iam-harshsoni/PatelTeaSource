using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatelTeaSource.ViewModel
{
    public class ShippingMasterVM
    {
        public long shipping_id { get; set; }
        public Nullable<long> user_id { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string companyName { get; set; }
        public string line1 { get; set; }
        public string line2 { get; set; }
        public string city { get; set; }
        public string pincode { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string landmark { get; set; }
        public Nullable<decimal> mobile { get; set; }
        public Nullable<int> status { get; set; }

        public virtual UserMasterVM user_master { get; set; }
    }
}