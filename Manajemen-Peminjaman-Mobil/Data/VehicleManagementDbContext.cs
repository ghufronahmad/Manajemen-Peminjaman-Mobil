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
            base.OnModelCreating(modelBuilder);
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


            // Seeding Admin
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = new Guid("11111111-1111-1111-1111-111111111111"),
                    Name = "Admin User",
                    Email = "admin@gmail.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("AdminPassword123"),
                    Role = Role.Admin
                },
                new User
                {
                    Id = new Guid("22222222-2222-2222-2222-222222222222"),
                    Name = "Approver 1",
                    Email = "approver1@gmail.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("ApproverPassword123"),
                    Role = Role.Approver
                },
                new User
                {
                    Id = new Guid("33333333-3333-3333-3333-333333333333"),
                    Name = "Approver 2",
                    Email = "approver2@gmail.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("ApproverPassword456"),
                    Role = Role.Approver
                }
            );
        }
    }


}
