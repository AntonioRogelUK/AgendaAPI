using AgendaAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaAPI.Context
{
    public class AgendaDbContext : DbContext
    {
        public AgendaDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Contacto>().HasIndex(x => x.Email).IsUnique();

            new ContactoEntityTypeConfiguration().Configure(modelBuilder.Entity<Contacto>());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Contacto> Contactos { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
    }
}
