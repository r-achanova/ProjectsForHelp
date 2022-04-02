using DentalSystem.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DentalSystem.Models.Hour;
using DentalSystem.Models.Reservation;

namespace DentalSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Hour> Hours { get; set; }
        public DbSet<Examination> Examinations { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        
      protected override void OnModelCreating(ModelBuilder builder)
        {
          /*  builder
                .Entity<Examination>()
                .HasOne(b => b.Patient)
                .WithMany(b => b.Examinations)
                .HasForeignKey(b => b.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Examination>()
                .HasOne(b => b.Doctor)
                .WithMany(b => b.Examinations)
                .HasForeignKey(b => b.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);*/

            builder
                .Entity<Reservation>()
               .HasOne<Hour>()
                .WithOne()
                .HasForeignKey<Hour>(b => b.ReservationId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .Entity<Patient>()
                .HasOne<ApplicationUser>()
                .WithOne()
                .HasForeignKey<Patient>(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .Entity<Doctor>()
                .HasOne<ApplicationUser>()
                .WithOne()
                .HasForeignKey<Doctor>(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);

        }

        
      //  public DbSet<DentalSystem.Models.Hour.AllHoursVM> AllHoursVM { get; set; }

        
      //  public DbSet<DentalSystem.Models.Reservation.AddReservationVM> AddReservationVM { get; set; }
    }
}
