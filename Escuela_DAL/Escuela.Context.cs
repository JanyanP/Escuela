﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Escuela_DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EscuelaEntities : DbContext
    {
        public EscuelaEntities()
            : base("name=EscuelaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Alumno> Alumno { get; set; }
        public DbSet<Ciudad> Ciudad { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Facultad> Facultad { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<Universidad> Universidad { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Materia> Materia { get; set; }
        public DbSet<MateriaAlumno> MateriaAlumno { get; set; }
    }
}
