﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MiCocina_WebAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MiCocinaBDEntities : DbContext
    {
        public MiCocinaBDEntities()
            : base("name=MiCocinaBDEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CLASIFICACION> CLASIFICACIONs { get; set; }
        public virtual DbSet<COMENTARIO> COMENTARIOs { get; set; }
        public virtual DbSet<FAVORITO> FAVORITOS { get; set; }
        public virtual DbSet<RECETA> RECETAS { get; set; }
        public virtual DbSet<USUARIO> USUARIOs { get; set; }
    }
}