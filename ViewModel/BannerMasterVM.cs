using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatelTeaSource.ViewModel
{
    public class BannerMasterVM
    {
        public int RowId { get; set; }
        public long Banner_id { get; set; }
        public string BannerImg { get; set; }
        public string BannerHeader { get; set; }
        public string BannerDesc { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<System.DateTime> Cdate { get; set; }
        public Nullable<System.DateTime> Udate { get; set; }
    }
}