using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Manajemen_Peminjaman_Mobil.Models
{
    public class EditBookingViewModel
    {
        public int Id { get; set; } // Wajib ada untuk edit

        [Required(ErrorMessage = "Keperluan wajib diisi")]
        public string Keperluan { get; set; }

        [Required(ErrorMessage = "Durasi wajib diisi")]
        [Range(1, int.MaxValue, ErrorMessage = "Durasi harus lebih dari 0")]
        public int Durasi { get; set; }

        [Required(ErrorMessage = "Tanggal wajib diisi")]
        [DataType(DataType.Date)]
        public DateTime Tanggal { get; set; }

        [Display(Name = "Nama Driver")]
        public string? DriverName { get; set; }

        [Required(ErrorMessage = "Lokasi Awal wajib dipilih")]
        [Display(Name = "Lokasi Awal")]
        public int StartMiningId { get; set; }

        [Required(ErrorMessage = "Lokasi Tujuan wajib dipilih")]
        [Display(Name = "Lokasi Tujuan")]
        public int EndMiningId { get; set; }

        [Required(ErrorMessage = "Pegawai wajib dipilih")]
        [Display(Name = "Pegawai Pemesan")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Kendaraan wajib dipilih")]
        [Display(Name = "Kendaraan")]
        public int VehicleId { get; set; }

        // Untuk mengisi data dropdown di View
        public SelectList? Minings { get; set; }
        public SelectList? Employees { get; set; }
        public SelectList? Vehicles { get; set; }
        public SelectList? Drivers { get; set; }
    }
}