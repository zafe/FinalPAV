﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Modelo
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class finalpavdbEntities : DbContext
    {
        public finalpavdbEntities()
            : base("name=finalpavdbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AdelantoSet> AdelantoSet { get; set; }
        public virtual DbSet<AdministradorSet> AdministradorSet { get; set; }
        public virtual DbSet<CamionSet> CamionSet { get; set; }
        public virtual DbSet<ConductorSet> ConductorSet { get; set; }
        public virtual DbSet<DistanciaSet> DistanciaSet { get; set; }
        public virtual DbSet<FincaSet> FincaSet { get; set; }
        public virtual DbSet<IngenioSet> IngenioSet { get; set; }
        public virtual DbSet<PagoSet> PagoSet { get; set; }
        public virtual DbSet<UsuarioSet> UsuarioSet { get; set; }
        public virtual DbSet<ViajeSet> ViajeSet { get; set; }
    }
}
