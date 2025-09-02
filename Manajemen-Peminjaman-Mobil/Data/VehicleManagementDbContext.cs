using Manajemen_Peminjaman_Mobil.Models;
using Manajemen_Peminjaman_Mobil.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Manajemen_Peminjaman_Mobil.Data
{
    public class VehicleManagementDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public VehicleManagementDbContext(DbContextOptions options) : base(options)
        {
        }

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
        public DbSet<ActivityLog> ActivityLogs { get; set; }



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
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Approver>()
                .HasOne(approver => approver.ApprovalLevel)
                .WithMany() // Asumsi ApprovalLevel tidak punya koleksi Approvers
                .HasForeignKey(approver => approver.ApprovalLevelId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasOne(employee => employee.Departement)
                .WithMany() 
                .HasForeignKey(employee => employee.DepartementId)
                .OnDelete(DeleteBehavior.Restrict);

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
                EmployeePositionId = 1,
                DepartementId = 1
            },
            new Employee
            {
                Id = 2,
                Name = "Jane Smith",
                Phone_Number = "08198765432",
                Tanggal_Lahir = new DateTime(1990, 8, 15),
                OfficeId = 1,
                EmployeePositionId = 2,
                DepartementId = 1
            },
            new Employee
            {
                Id = 3,
                Name = "Josh S",
                Phone_Number = "08198765422",
                Tanggal_Lahir = new DateTime(1980, 7, 10),
                OfficeId = 1,
                EmployeePositionId = 1,
                DepartementId = 2
            },
            new Employee
            {
                Id = 4,
                Name = "John Smith",
                Phone_Number = "08198765422",
                Tanggal_Lahir = new DateTime(1980, 7, 10),
                OfficeId = 1,
                EmployeePositionId = 2,
                DepartementId = 2
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
                VehicleId = 1,
                Status= "Menunggu",
                DriverName = "Budi"
            }
        );

        }
    }


}
