﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project.Areas.JobFront.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SuperUniversityEntitiesFront : DbContext
    {
        public SuperUniversityEntitiesFront()
            : base("name=SuperUniversityEntitiesFront")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CompanyJobTypeTable> CompanyJobTypeTable { get; set; }
        public virtual DbSet<EmployerCompany> EmployerCompany { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<Jobtime> Jobtime { get; set; }
        public virtual DbSet<JobTypes> JobTypes { get; set; }
    }
}