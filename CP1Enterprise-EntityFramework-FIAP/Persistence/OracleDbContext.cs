using CP1Enterprise_EntityFramework_FIAP.Web.Entities;
using Microsoft.EntityFrameworkCore;

namespace CP1Enterprise_EntityFramework_FIAP.Web.Persistence;

public class OracleDbContext : DbContext
{
    public OracleDbContext(DbContextOptions<OracleDbContext>
        options) : base(options)
    {
    }

    public DbSet<Carta> Cartas { get; set; }
    public DbSet<Colecao> Colecoes { get; set; }
    public DbSet<Idioma> Idiomas { get; set; }
    public DbSet<Ilustrador> Ilustradores { get; set; }
    public DbSet<Links> Links { get; set; }
    public DbSet<RegrasEspeciais> RegrasEspeciais { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carta>()
            .HasOne(carta => carta.Colecoes)  // Relacionamento de Carta com Colecao
            .WithMany(colecao => colecao.Cartas)  // Uma Colecao pode ter várias Cartas
            .HasForeignKey(carta => carta.ColecaoId)  // Chave estrangeira em Carta
            .OnDelete(DeleteBehavior.Cascade);
    }

}