using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatelTeaSource.ViewModel
{
    public class UserLoginVM
    {
        public long id { get; set; }
        public Nullable<long> userId { get; set; }
        public Nullable<System.DateTime> lastLogin { get; set; }
        public Nullable<System.DateTime> createdDate { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }

        public virtual NewUserRegistrationVM NewUserRegister { get; set; }
    }
}