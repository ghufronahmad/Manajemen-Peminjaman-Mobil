using Manajemen_Peminjaman_Mobil.Models;
using Manajemen_Peminjaman_Mobil.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Manajemen_Peminjaman_Mobil.Data
{
    public class VehicleManagementDbContext : DbContext
    {
        public VehicleManagementDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<EmployeePosition> EmployeePositions { get; set; }
        public DbSet<Departement> Departements { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Mining> Minings { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ServiceSchedule> ServiceSchedules { get; set; }
        public DbSet<FuelConsumption> FuelConsumptions { get; set; }
        public DbSet<Approver> Approvers { get; set; }
        public DbSet<VehicleBooking> VehicleBookings { get; set; }
        public DbSet<ApprovalLevel> ApproversLevels { get; set; }
        public DbSet<ApprovalProcess> approvalProcesses { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Set delete behavior for VehicleBooking
            modelBuilder.Entity<VehicleBooking>()
                .HasOne(vb => vb.Mining)
                .WithMany() // Assuming a one-to-many relationship
                .HasForeignKey(vb => vb.StartMiningId)
                .OnDelete(DeleteBehavior.Restrict); // Use Restrict or NoAction to prevent cascade delete

            modelBuilder.Entity<VehicleBooking>()
                .HasOne(vb => vb.Mining)
                .WithMany() // Assuming a one-to-many relationship
                .HasForeignKey(vb => vb.EndMiningId)
                .OnDelete(DeleteBehavior.Restrict); // Use Restrict or NoAction to prevent cascade delete

            modelBuilder.Entity<VehicleBooking>()
                .HasOne(vb => vb.Employee)
                .WithMany() // Assuming a one-to-many relationship
                .HasForeignKey(vb => vb.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete for Employee

            modelBuilder.Entity<VehicleBooking>()
                .HasOne(vb => vb.Vehicle)
                .WithMany() // Assuming a one-to-many relationship
                .HasForeignKey(vb => vb.VehicleId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete for Vehicle
        }
    }


}
