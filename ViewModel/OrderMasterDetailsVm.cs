using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatelTeaSource.ViewModel
{
    public class OrderMasterDetailsVm
    {
        public int rowNo { get; set; }
        public string productName { get; set; }
        public long order_detail_id { get; set; }
        public Nullable<long> order_id { get; set; }
        public Nullable<long> pid { get; set; }
        public Nullable<int> qty { get; set; }
        public string rate { get; set; }
        public string taxRate { get; set; }
        public string amount { get; set; }
        public Nullable<System.DateTime> cdate { get; set; }
        public Nullable<System.DateTime> udate { get; set; }
        public Nullable<long> offerId { get; set; }

        public Nullable<decimal> subTotal { get; set; }
        public Nullable<decimal> cgst { get; set; }
        public Nullable<decimal> sgst{ get; set; }
        public Nullable<decimal> taxableAmount { get; set; }
        public Nullable<decimal> shipping { get; set; }
    }
}