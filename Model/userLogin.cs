//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PatelTeaSource.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class userLogin
    {
        public long id { get; set; }
        public Nullable<long> userId { get; set; }
        public Nullable<System.DateTime> lastLogin { get; set; }
        public Nullable<System.DateTime> createdDate { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
    
        public virtual NewUserRegister NewUserRegister { get; set; }
    }
}
