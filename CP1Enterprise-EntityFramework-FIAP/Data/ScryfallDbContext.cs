using CP1Enterprise_EntityFramework_FIAP.Web.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace CP1Enterprise_EntityFramework_FIAP.Web.Data
{
    public class ScryfallDbContext : DbContext
    {
        public ScryfallDbContext(DbContextOptions<ScryfallDbContext> options) : base(options) { }
        public DbSet<Carta> Cartas { get; set; }
        public DbSet<Colecao> Colecoes { get; set; }
        public DbSet<Idioma> Idiomas { get; set; }
        public DbSet<Ilustrador> Ilustradores { get; set; }
        public DbSet<Links> Links { get; set; }
        public DbSet<RegrasEspeciais> RegrasEspeciais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Quarto)
                .WithMany(q => q.Reservas)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}