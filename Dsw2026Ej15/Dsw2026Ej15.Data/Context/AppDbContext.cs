using Dsw2026Ej15.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dsw2026Ej15.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Doctor> Doctors => Set<Doctor>();
        public DbSet<Speciality> Specialities => Set<Speciality>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Speciality>(entity =>
            {
                entity.HasKey(s => s.Id);

                entity.Property(s => s.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(s => s.Description)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.HasData(
                    new Speciality("Cardiología", "...", Guid.Parse("8a1f3b78-3f66-4d68-8d6e-1c5b9c7a2f41")),
                    new Speciality("Pediatría", "...", Guid.Parse("f4d2c9a1-7b3e-4f8d-9c61-2e7a5d8b3c12"))
                );
            });

            modelBuilder.Entity<Speciality>(entity =>
            {
                entity.HasKey(s => s.Id);

                entity.Property(s => s.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(s => s.Description)
                    .IsRequired()
                    .HasMaxLength(300);
            });
        }
    }
}