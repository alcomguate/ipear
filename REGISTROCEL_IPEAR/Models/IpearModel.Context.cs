﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace REGISTROCEL_IPEAR.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class IPEAREntities : DbContext
    {
        public IPEAREntities()
            : base("name=IPEAREntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CAT_CIUDAD> CAT_CIUDAD { get; set; }
        public virtual DbSet<CAT_COLOR> CAT_COLOR { get; set; }
        public virtual DbSet<CAT_FABRICA> CAT_FABRICA { get; set; }
        public virtual DbSet<CAT_GAMA> CAT_GAMA { get; set; }
        public virtual DbSet<CAT_PAIS> CAT_PAIS { get; set; }
        public virtual DbSet<REG_DISPOSITIVO> REG_DISPOSITIVO { get; set; }
    }
}
