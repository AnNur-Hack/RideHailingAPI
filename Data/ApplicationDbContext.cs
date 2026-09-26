using Microsoft.EntityFrameworkCore;
using RideHailingAPI.Domain.Entities;

namespace RideHailingAPI.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
   public DbSet<User>  Users { get; set; }
   public DbSet<Otp>  Otps { get; set; }
   public DbSet<DriverProfile>  DriverProfiles { get; set; }
   public DbSet<Ride>  Rides { get; set; }
   public DbSet<Vehicle>  Vehicles { get; set; }
   public DbSet<AuditLog>  AuditLogs { get; set; }


   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
       modelBuilder.Entity<Otp>()
           .HasOne(o => o.User)
           .WithMany(u => u.Otps)
           .HasForeignKey(o => o.UserId)
           .OnDelete(DeleteBehavior.Cascade);
       
       modelBuilder.Entity<DriverProfile>()
           .HasOne(d => d.User)
           .WithOne(u => u.DriverProfile)
           .HasForeignKey<DriverProfile>(d => d.UserId)
           .OnDelete(DeleteBehavior.Cascade);
       
       modelBuilder.Entity<Vehicle>()
           .HasOne(v => v.DriverProfile)
           .WithOne(d => d.Vehicle)
           .HasForeignKey<Vehicle>(d => d.DriverProfileId)
           .OnDelete(DeleteBehavior.Cascade);
       
       modelBuilder.Entity<Ride>()
           .HasOne(r => r.Passenger)
           .WithMany(u => u.PassengerRides)
           .HasForeignKey(r => r.PassengerId)
           .OnDelete(DeleteBehavior.Restrict);
       
       modelBuilder.Entity<Ride>()
           .HasOne(r => r.Driver)
           .WithMany(u => u.DriverRides)
           .HasForeignKey(r => r.DriverId)
           .OnDelete(DeleteBehavior.Restrict);
       
       modelBuilder.Entity<AuditLog>()
           .HasOne(a => a.User)
           .WithMany(u => u.AuditLogs)
           .HasForeignKey(a => a.UserId)
           .OnDelete(DeleteBehavior.Restrict);
       
       modelBuilder.Entity<User>()
           .HasIndex(u => u.Email)
           .IsUnique();
       
       modelBuilder.Entity<User>()
           .HasIndex(u => u.UserId)
           .IsUnique();
       
       modelBuilder.Entity<User>()
           .HasIndex(u => u.PhoneNumber)
           .IsUnique();
       
       modelBuilder.Entity<Ride>()
           .HasIndex(r => r.RideReference)
           .IsUnique();
       
       modelBuilder.Entity<Vehicle>()
           .HasIndex(v => v.PlateNumber)
           .IsUnique();
       
       modelBuilder.Entity<DriverProfile>()
           .HasIndex(d => d.LicenseNumber)
           .IsUnique();
       
       base.OnModelCreating(modelBuilder);
   }
}