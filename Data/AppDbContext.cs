using Microsoft.EntityFrameworkCore;
using Actividad_6.Models;

namespace Actividad_6.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Juego> Juegos { get; set; }
    public DbSet<VersionJuego> VersionJuegos { get; set; }
    public DbSet<Servidor> Servidores { get; set; }
    public DbSet<ConfiguracionServidor> ConfiguracionServidores { get; set; }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<EventoServidor> EventosServidores { get; set; }
    public DbSet<PuertoServidor> PuertosServidores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<EventoServidor>()
            .HasOne(e => e.Servidor)
            .WithMany()
            .HasForeignKey(e => e.IdServidor);

        modelBuilder.Entity<EventoServidor>()
            .HasOne(e => e.Usuario)
            .WithMany(u => u.Eventos)
            .HasForeignKey(e => e.IdUsuario);

        modelBuilder.Entity<PuertoServidor>()
            .HasOne(p => p.Servidor)
            .WithMany()
            .HasForeignKey(p => p.IdServidor);
    }
}