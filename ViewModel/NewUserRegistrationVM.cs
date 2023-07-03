using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatelTeaSource.ViewModel
{
    public class NewUserRegistrationVM
    {

        public long userId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string fullName { get; set; }
        public string emailId { get; set; }
        public Nullable<int> status { get; set; }
        public string role { get; set; }
        public string userType { get; set; }
        public Nullable<System.DateTime> cDate { get; set; }
        public Nullable<System.DateTime> uDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserLoginVM> userLogins { get; set; }
    }
}