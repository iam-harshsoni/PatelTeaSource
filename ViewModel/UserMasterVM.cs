using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatelTeaSource.ViewModel
{
    public class UserMasterVM
    {
        public long user_id { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string company_name { get; set; }
        public string addLine1 { get; set; }
        public string addLine2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string pincode { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public Nullable<System.DateTime> dob { get; set; }
        public string cdate { get; set; }
        public string udate { get; set; }
    }
}