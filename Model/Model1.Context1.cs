﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class patelteaEntities : DbContext
    {
        public patelteaEntities()
            : base("name=patelteaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<awardsCertificate> awardsCertificates { get; set; }
        public virtual DbSet<banner_master> banner_master { get; set; }
        public virtual DbSet<Company_master> Company_master { get; set; }
        public virtual DbSet<distibuter_master> distibuter_master { get; set; }
        public virtual DbSet<feedback_master> feedback_master { get; set; }
        public virtual DbSet<NewUserRegister> NewUserRegisters { get; set; }
        public virtual DbSet<userLogin> userLogins { get; set; }
        public virtual DbSet<contact_master> contact_master { get; set; }
        public virtual DbSet<GlobalParameter> GlobalParameters { get; set; }
        public virtual DbSet<blog_master> blog_master { get; set; }
    }
}