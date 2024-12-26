using AppConsola.Entidades;
using AppConsola.Entidades.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AppConsola
{
    public class ContextoBd : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=DESKTOP-MNIIDSE;Database=ProyectoAppConsolaFisurama;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveMaxLength(100);
        }


        public DbSet<Clientes> Clientes => Set<Clientes>();
        public DbSet<Productos> Productos => Set<Productos>();

    }
}
