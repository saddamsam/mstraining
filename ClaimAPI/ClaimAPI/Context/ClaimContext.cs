using ClaimAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClaimAPI.Context
{
    public class ClaimContext : DbContext
    {
        public ClaimContext(DbContextOptions<ClaimContext> dbContextOptions) : base(dbContextOptions) { 
        
            Database.EnsureCreated();
        }

        public DbSet<ClaimDetails> ClaimDetails { get; set; } 
        public DbSet<FIRDetails> FIRDetails { get; set; } 
        public DbSet<DriverDetails> DriverDetails { get; set; } 
        public DbSet<DriverAddress> DriverAddresses { get; set; } 
        public DbSet<LicenseDetails> LicenseDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<DriverDetails>()
                .Property(m => m.Gender)
                .HasConversion<string>()
                .HasMaxLength(30);

            modelBuilder.Entity<ClaimDetails>()
                .Property(m => m.IsReportedToPolice)
                .HasConversion<string>()
                .HasMaxLength(30);

            modelBuilder.Entity<FIRDetails>()
                .Property(m => m.EventType)
                .HasConversion<string>()
                .HasMaxLength(50);

            modelBuilder.Entity<LicenseDetails>()
                .Property(m => m.VehicleClass)
                .HasConversion<string>()
                .HasMaxLength(30);

            modelBuilder.Entity<LicenseDetails>()
               .Property(m => m.DriverType)
               .HasConversion<string>()
               .HasMaxLength(30);
        }
    }
}
