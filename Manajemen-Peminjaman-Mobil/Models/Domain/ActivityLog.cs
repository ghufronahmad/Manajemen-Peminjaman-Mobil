// File: Models/Domain/ActivityLog.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace Manajemen_Peminjaman_Mobil.Models.Domain
{
    public class ActivityLog
    {
        public int Id { get; set; }

        [Required]
        public Guid ActorUserId { get; set; } // ID user yang melakukan aksi

        [MaxLength(256)]
        public string ActorName { get; set; } // Snapshot nama user saat itu

        [Required]
        [MaxLength(100)]
        public string Action { get; set; } // Aksi yang dilakukan, misal: "APPROVE_BOOKING"

        [Required]
        public string Description { get; set; } // Deskripsi yang mudah dibaca

        public DateTime Timestamp { get; set; } = DateTime.Now; // Waktu kejadian
    }
}