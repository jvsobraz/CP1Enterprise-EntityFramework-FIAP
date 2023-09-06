using System;
using CP1Enterprise_EntityFramework_FIAP.Models;
using Microsoft.EntityFrameworkCore;
using CP1.Models;

namespace CP1Enterprise_EntityFramework_FIAP.Persistence
{
    public class OracleDbContext : DbContext
    {
        public OracleDbContext()
        {
        }

        public OracleDbContext(DbContextOptions<OracleDbContext> options)
        : base(options)
        {

        }
        public DbSet<Carta> Cartas { get; set; }

        public DbSet<Colecao> Colecoes { get; set; }

        public DbSet<Links> Links { get; set; }

        public DbSet<RegrasEspeciais> RegrasEspeciais { get; set; }

        public DbSet<Filtro> Filtros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Um pra um

            modelBuilder.Entity<Carta>()
                .HasOne(c => c.Links)
                .WithOne(l => l.Carta)
                .HasForeignKey<Links>(l => l.Id);

            modelBuilder.Entity<Carta>()
                .HasOne(c => c.Ilustrador)
                .WithOne(i => i.Carta)
                .HasForeignKey<Ilustrador>(i => i.Id);

            modelBuilder.Entity<Carta>()
                .HasOne(c => c.Colecao) // Relacionamento de Carta com Colecao
                .WithOne(co => co.Carta) // Uma Colecao pode ter várias Cartas
                .HasForeignKey<Colecao>(co => co.Id); // Chave estrangeira em Carta

            base.OnModelCreating(modelBuilder);
        }





    }
}

