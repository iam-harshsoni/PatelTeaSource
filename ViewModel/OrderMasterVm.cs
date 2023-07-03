using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatelTeaSource.ViewModel
{
    public class OrderMasterVm
    {

     
        public long order_id { get; set; }
        public Nullable<long> user_id { get; set; }
       
        public string order_datetime { get; set; }
        public Nullable<int> order_status { get; set; }
        public string cdate { get; set; }
        public string udate { get; set; }
        public Nullable<decimal> gtotal { get; set; }
        public Nullable<long> offer_id { get; set; }
        public Nullable<long> cartIdTemp { get; set; }
    }
}