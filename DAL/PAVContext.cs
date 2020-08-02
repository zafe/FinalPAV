using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class PAVContext : DbContext
    {

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Viaje> Viajes { get; set; }
        public DbSet<Finca> Finca { get; set; }
        public DbSet<Ingenio> Ingenio { get; set; }
        public DbSet<Distancia> Distancia { get; set; }
        //public DbSet<ReglasNegocio> ReglasNegocios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("" +
                "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = PAVData ");
        }

    }
}
