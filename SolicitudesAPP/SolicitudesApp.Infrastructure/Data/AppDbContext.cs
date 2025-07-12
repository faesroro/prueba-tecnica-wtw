using Microsoft.EntityFrameworkCore;
using SolicitudesApp.Domain.Entities;

namespace SolicitudesApp.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Solicitud> Solicitudes => Set<Solicitud>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Solicitud>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Tipo).IsRequired();
                entity.Property(e => e.Estado).IsRequired();
                entity.Property(e => e.FechaCreacion).IsRequired();
                entity.Property(e => e.Datos).HasColumnType("nvarchar(max)");
            });
        }
    }
}