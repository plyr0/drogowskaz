﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class drogowskazEntities : DbContext
    {
        public drogowskazEntities()
            : base("name=drogowskazEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Church> Churches { get; set; }
        public virtual DbSet<Rule> Rules { get; set; }
        public virtual DbSet<Mass> Masses { get; set; }
        public virtual DbSet<LiturgicalCycle> LiturgicalCycles { get; set; }
    }
}
