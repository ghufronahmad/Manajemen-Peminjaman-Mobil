using Manajemen_Peminjaman_Mobil.Models;
using Manajemen_Peminjaman_Mobil.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
                .HasOne(vb => vb.StartMining)
                .WithMany() // Assuming a one-to-many relationship
                .HasForeignKey(vb => vb.StartMiningId)
                .OnDelete(DeleteBehavior.Restrict); // Use Restrict or NoAction to prevent cascade delete

            modelBuilder.Entity<VehicleBooking>()
                .HasOne(vb => vb.EndMining)
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

            // Seeding Position
            modelBuilder.Entity<EmployeePosition>().HasData(
                new EmployeePosition { Id = 1, Jabatan = "Kepala Bagian Pool"},
                new EmployeePosition { Id = 2, Jabatan = "Manager" }
                );

            // Seeding Departement
            modelBuilder.Entity<Departement>().HasData(
                new Departement { Id = 1, Departement_Name = "Hr"},
                new Departement { Id = 2, Departement_Name = "Marketing" },
                new Departement { Id = 3, Departement_Name = "Finance" },
                new Departement { Id = 4, Departement_Name = "Production" },
                new Departement { Id = 5, Departement_Name = "IT" }
                );

            // Seeding Region
            modelBuilder.Entity<Region>().HasData(
                new Region { Id = 1, Region_Name = "Region A" },
                new Region { Id = 2, Region_Name = "Region B" },
                new Region { Id = 3, Region_Name = "Region C" },
                new Region { Id = 4, Region_Name = "Region D" },
                new Region { Id = 5, Region_Name = "Region E" },
                new Region { Id = 6, Region_Name = "Region F" }
                );


            // Seeding Mining
            modelBuilder.Entity<Mining>().HasData(
                new Mining { Id = 1, Mining_Name = "Mining A", RegionId = 2 },
                new Mining { Id = 2, Mining_Name = "Mining B", RegionId = 3 },
                new Mining { Id = 3, Mining_Name = "Mining C", RegionId = 4 }
                );

            //Seeding Office 
            modelBuilder.Entity<Office>().HasData(
                new Office { Id = 1, Office_Name = "Office 1", RegionId = 1, Unit = Unit.Pusat },
                new Office { Id = 2, Office_Name = "Office 2", RegionId = 1, Unit = Unit.Cabang }
                );

            modelBuilder.Entity<Employee>().HasData(
            new Employee
            {
                Id = 1,
                Name = "John Doe",
                Phone_Number = "08123456789",
                Tanggal_Lahir = new DateTime(1985, 5, 20),
                OfficeId = 1,
                EmployeePositionId = 1
            },
            new Employee
            {
                Id = 2,
                Name = "Jane Smith",
                Phone_Number = "08198765432",
                Tanggal_Lahir = new DateTime(1990, 8, 15),
                OfficeId = 1,
                EmployeePositionId = 2
            },
            new Employee
            {
                Id = 3,
                Name = "John Smith",
                Phone_Number = "08198765422",
                Tanggal_Lahir = new DateTime(1980, 7, 10),
                OfficeId = 1,
                EmployeePositionId = 2
            }
        );

            modelBuilder.Entity<Vehicle>().HasData(
            new Vehicle
            {
                Id = 1,
                Name = "Toyota Avanza",
                Plat_Nomor = "L 1234 AB",
                Type = Tipe.Personal,
                Tahun_Kendaraan = "2020",
                Status_Kepemilikan = Status.Perusahaan
            },
            new Vehicle
            {
                Id = 2,
                Name = "Isuzu Elf",
                Plat_Nomor = "B 9876 XY",
                Type = Tipe.Personal,
                Tahun_Kendaraan = "2019",
                Status_Kepemilikan = Status.Sewa
            },
            new Vehicle
            {
                Id = 3,
                Name = "Mitsubishi L300",
                Plat_Nomor = "KT 9124 XY",
                Type = Tipe.Barang,
                Tahun_Kendaraan = "2015",
                Status_Kepemilikan = Status.Perusahaan
            },
            new Vehicle
            {
                Id = 4,
                Name = "Mitsubishi Canter",
                Plat_Nomor = "KT 1204 XY",
                Type = Tipe.Barang,
                Tahun_Kendaraan = "2010",
                Status_Kepemilikan = Status.Perusahaan
            }
        );

            modelBuilder.Entity<ApprovalLevel>().HasData(
                new ApprovalLevel { Id = 1, Name = "Level 1", Level = 1 },
                new ApprovalLevel { Id = 2, Name = "Level 2", Level = 2 }
                );

            modelBuilder.Entity<Approver>().HasData(
                new Approver
                {
                    Id = 1,
                    EmployeeId = 2,
                    DepartementId = 1,
                    UserId = new Guid("22222222-2222-2222-2222-222222222222")
                },
                new Approver
                {
                    Id = 2,
                    EmployeeId = 2,
                    DepartementId = 4,
                    UserId = new Guid("33333333-3333-3333-3333-333333333333")
                });

            modelBuilder.Entity<VehicleBooking>().HasData(
            new VehicleBooking
            {
                Id = 1,
                Keperluan = "Site inspection",
                Durasi = 3,
                Tanggal = DateTime.Now.AddDays(-1),
                StartMiningId = 1,
                EndMiningId = 2,
                EmployeeId = 1,
                VehicleId = 1
            },
            new VehicleBooking
            {
                Id = 2,
                Keperluan = "Equipment transfer",
                Durasi = 5,
                Tanggal = DateTime.Now.AddDays(-2),
                StartMiningId = 2,
                EndMiningId = 3,
                EmployeeId = 1,
                VehicleId = 2
            }
        );

        }
    }


}
