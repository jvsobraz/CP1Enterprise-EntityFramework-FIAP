using HookingHotels.Web.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace HookingHotels.Web.Data;

public class HookingDbContext : DbContext
{
    public HookingDbContext(DbContextOptions<HookingDbContext>
        options) : base(options)
    {
    }

    public DbSet<Hospede> Hospedes { get; set; }
    public DbSet<Quarto> Quartos { get; set; }
    public DbSet<Reserva> Reservas { get; set; }
    public DbSet<Hotel> Hoteis { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Reserva>()
            .HasOne(r => r.Quarto)
            .WithMany(q => q.Reservas)
            .OnDelete(DeleteBehavior.Cascade);
    }
}