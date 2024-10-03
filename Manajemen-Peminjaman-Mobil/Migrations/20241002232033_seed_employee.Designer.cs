﻿// <auto-generated />
using System;
using Manajemen_Peminjaman_Mobil.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Manajemen_Peminjaman_Mobil.Migrations
{
    [DbContext(typeof(VehicleManagementDbContext))]
    [Migration("20241002232033_seed_employee")]
    partial class seed_employee
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Manajemen_Peminjaman_Mobil.Models.ApprovalProcess", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ApprovalLevelId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Approved_At")
                        .HasColumnType("datetime2");

                    b.Property<int>("ApproverId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Rejected_At")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("VehicleBookingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApprovalLevelId");

                    b.HasIndex("ApproverId");

                    b.HasIndex("VehicleBookingId");

                    b.ToTable("approvalProcesses");
                });

            modelBuilder.Entity("Manajemen_Peminjaman_Mobil.Models.Domain.ApprovalLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ApproversLevels");
                });

            modelBuilder.Entity("Manajemen_Peminjaman_Mobil.Models.Domain.Approver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartementId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DepartementId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("UserId");

                    b.ToTable("Approvers");
                });

            modelBuilder.Entity("Manajemen_Peminjaman_Mobil.Models.Domain.Departement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Departement_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departements");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Departement_Name = "Hr"
                        },
                        new
                        {
                            Id = 2,
                            Departement_Name = "Marketing"
                        },
                        new
                        {
                            Id = 3,
                            Departement_Name = "Finance"
                        },
                        new
                        {
                            Id = 4,
                            Departement_Name = "Production"
                        },
                        new
                        {
                            Id = 5,
                            Departement_Name = "IT"
                        });
                });

            modelBuilder.Entity("Manajemen_Peminjaman_Mobil.Models.Domain.EmployeePosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Jabatan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EmployeePositions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Jabatan = "Kepala Bagian Pool"
                        },
                        new
                        {
                            Id = 2,
                            Jabatan = "Manager"
                        });
                });

            modelBuilder.Entity("Manajemen_Peminjaman_Mobil.Models.Domain.Mining", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Mining_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Minings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Mining_Name = "Mining A",
                            RegionId = 2
                        },
                        new
                        {
                            Id = 2,
                            Mining_Name = "Mining B",
                            RegionId = 3
                        },
                        new
                        {
                            Id = 3,
                            Mining_Name = "Mining C",
                            RegionId = 4
                        });
                });

            modelBuilder.Entity("Manajemen_Peminjaman_Mobil.Models.Domain.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Region_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Region_Name = "Region A"
                        },
                        new
                        {
                            Id = 2,
                            Region_Name = "Region B"
                        },
                        new
                        {
                            Id = 3,
                            Region_Name = "Region C"
                        },
                        new
                        {
                            Id = 4,
                            Region_Name = "Region D"
                        },
                        new
                        {
                            Id = 5,
                            Region_Name = "Region E"
                        },
                        new
                        {
                            Id = 6,
                            Region_Name = "Region F"
                        });
                });

            modelBuilder.Entity("Manajemen_Peminjaman_Mobil.Models.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("11111111-1111-1111-1111-111111111111"),
                            Email = "admin@gmail.com",
                            Name = "Admin User",
                            Password = "$2a$11$jm/ssG4rCbybAhR9XypJUeIiYoYYFAP5cuejAwGZziNbDLi8wbhXa",
                            Role = 0
                        },
                        new
                        {
                            Id = new Guid("22222222-2222-2222-2222-222222222222"),
                            Email = "approver1@gmail.com",
                            Name = "Approver 1",
                            Password = "$2a$11$cJ6eTejoy2feRF/AwTd9R.xJMC0S9PI.okNZnY97iFqxdzO7yoOm6",
                            Role = 1
                        },
                        new
                        {
                            Id = new Guid("33333333-3333-3333-3333-333333333333"),
                            Email = "approver2@gmail.com",
                            Name = "Approver 2",
                            Password = "$2a$11$eefl9QJD/K11zDewLZHveuPm/IZthB9Qk7AXfHglqLfocJKCqbp9K",
                            Role = 1
                        });
                });

            modelBuilder.Entity("Manajemen_Peminjaman_Mobil.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmployeePositionId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OfficeId")
                        .HasColumnType("int");

                    b.Property<string>("Phone_Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Tanggal_Lahir")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EmployeePositionId");

                    b.HasIndex("OfficeId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EmployeePositionId = 1,
                            Name = "John Doe",
                            OfficeId = 1,
                            Phone_Number = "08123456789",
                            Tanggal_Lahir = new DateTime(1985, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            EmployeePositionId = 2,
                            Name = "Jane Smith",
                            OfficeId = 1,
                            Phone_Number = "08198765432",
                            Tanggal_Lahir = new DateTime(1990, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            EmployeePositionId = 2,
                            Name = "John Smith",
                            OfficeId = 1,
                            Phone_Number = "08198765422",
                            Tanggal_Lahir = new DateTime(1980, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Manajemen_Peminjaman_Mobil.Models.FuelConsumption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Biaya")
                        .HasColumnType("int");

                    b.Property<string>("Keterangan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Odometer")
                        .HasColumnType("int");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VehicleId");

                    b.ToTable("FuelConsumptions");
                });

            modelBuilder.Entity("Manajemen_Peminjaman_Mobil.Models.Office", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Office_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.Property<int>("Unit")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Offices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Office_Name = "Office 1",
                            RegionId = 1,
                            Unit = 1
                        },
                        new
                        {
                            Id = 2,
                            Office_Name = "Office 2",
                            RegionId = 1,
                            Unit = 0
                        });
                });

            modelBuilder.Entity("Manajemen_Peminjaman_Mobil.Models.ServiceSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Biaya")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Keterangan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Tanggal_Service")
                        .HasColumnType("datetime2");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VehicleId");

                    b.ToTable("ServiceSchedules");
                });

            modelBuilder.Entity("Manajemen_Peminjaman_Mobil.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Plat_Nomor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status_Kepemilikan")
                        .HasColumnType("int");

                    b.Property<string>("Tahun_Kendaraan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("Manajemen_Peminjaman_Mobil.Models.VehicleBooking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Durasi")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("EndMiningId")
                        .HasColumnType("int");

                    b.Property<string>("Keperluan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StartMiningId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Tanggal")
                        .HasColumnType("datetime2");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("EndMiningId");

                    b.HasIndex("VehicleId");

                    b.ToTable("VehicleBookings");
                });

            modelBuilder.Entity("Manajemen_Peminjaman_Mobil.Models.ApprovalProcess", b =>
                {
                    b.HasOne("Manajemen_Peminjaman_Mobil.Models.Domain.ApprovalLevel", "ApprovalLevel")
                        .WithMany()
                        .HasForeignKey("ApprovalLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Manajemen_Peminjaman_Mobil.Models.Domain.Approver", "Approver")
                        .WithMany()
                        .HasForeignKey("ApproverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Manajemen_Peminjaman_Mobil.Models.VehicleBooking", "VehicleBooking")
                        .WithMany()
                        .HasForeignKey("VehicleBookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApprovalLevel");

                    b.Navigation("Approver");

                    b.Navigation("VehicleBooking");
                });

            modelBuilder.Entity("Manajemen_Peminjaman_Mobil.Models.Domain.Approver", b =>
                {
                    b.HasOne("Manajemen_Peminjaman_Mobil.Models.Domain.Departement", "Departement")
                        .WithMany()
                        .HasForeignKey("DepartementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Manajemen_Peminjaman_Mobil.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Manajemen_Peminjaman_Mobil.Models.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departement");

                    b.Navigation("Employee");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Manajemen_Peminjaman_Mobil.Models.Domain.Mining", b =>
                {
                    b.HasOne("Manajemen_Peminjaman_Mobil.Models.Domain.Region", "Region")
                        .WithMany("Minings")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");
                });

            modelBuilder.Entity("Manajemen_Peminjaman_Mobil.Models.Employee", b =>
                {
                    b.HasOne("Manajemen_Peminjaman_Mobil.Models.Domain.EmployeePosition", "Position")
                        .WithMany()
                        .HasForeignKey("EmployeePositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Manajemen_Peminjaman_Mobil.Models.Office", "Office")
                        .WithMany()
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Office");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("Manajemen_Peminjaman_Mobil.Models.FuelConsumption", b =>
                {
                    b.HasOne("Manajemen_Peminjaman_Mobil.Models.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Manajemen_Peminjaman_Mobil.Models.Office", b =>
                {
                    b.HasOne("Manajemen_Peminjaman_Mobil.Models.Domain.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");
                });

            modelBuilder.Entity("Manajemen_Peminjaman_Mobil.Models.ServiceSchedule", b =>
                {
                    b.HasOne("Manajemen_Peminjaman_Mobil.Models.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Manajemen_Peminjaman_Mobil.Models.VehicleBooking", b =>
                {
                    b.HasOne("Manajemen_Peminjaman_Mobil.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Manajemen_Peminjaman_Mobil.Models.Domain.Mining", "Mining")
                        .WithMany()
                        .HasForeignKey("EndMiningId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Manajemen_Peminjaman_Mobil.Models.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Mining");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Manajemen_Peminjaman_Mobil.Models.Domain.Region", b =>
                {
                    b.Navigation("Minings");
                });
#pragma warning restore 612, 618
        }
    }
}
