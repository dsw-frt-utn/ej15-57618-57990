using Dsw2026Ej15.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej15.Data
{
    public class Dsw2026Ej15DbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Speciality> Specialities { get; set; }


        public Dsw2026Ej15DbContext(DbContextOptions<Dsw2026Ej15DbContext> options) : base(options) { 
        


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Doctor>(e =>
            {
                e.ToTable("Doctor");
                e.Property(d => d.Name).HasMaxLength(100).IsRequired();
                e.Property(d => d.LicenseNumber).HasMaxLength(50).IsRequired();
                e.Property(d => d.IsActive).IsRequired();
                e.Property(d => d.SpecialityId).IsRequired();
              
            });

            modelBuilder.Entity<Speciality>(e =>
            {
                e.ToTable("Speciality");
                e.Property(s => s.Name).HasMaxLength(100).IsRequired();
                e.Property(s => s.Description).HasMaxLength(500).IsRequired();

                e.HasMany(s => s.Doctors)
                .WithOne(d => d.Speciality)
                .HasForeignKey(d => d.SpecialityId);
                //     .OnDelete(DeleteBehavior.Restrict);

            });
            
            
            

        }

    }

}
