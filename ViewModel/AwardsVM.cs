using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatelTeaSource.ViewModel
{
    public class AwardsVM
    {

        public long awardId { get; set; }
        public string awardImg { get; set; }
        public string description { get; set; }
        public string year { get; set; }
        public Nullable<System.DateTime> cdate { get; set; }
        public Nullable<System.DateTime> udate { get; set; }

    }
}