﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace obenimdeoyuncagimvc.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class mvc_oyuncakEntities : DbContext
    {
        public mvc_oyuncakEntities()
            : base("name=mvc_oyuncakEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<emanetoyuncaklar> emanetoyuncaklar { get; set; }
        public virtual DbSet<oyuncak> oyuncak { get; set; }
        public virtual DbSet<sepet> sepet { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<uye> uye { get; set; }
    }
}
