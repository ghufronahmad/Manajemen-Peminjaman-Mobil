using Manajemen_Peminjaman_Mobil.Models.Domain;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manajemen_Peminjaman_Mobil.Models
{
    public class VehicleBooking
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Keperluan is required")]
        public string Keperluan { get; set; }

        [Required(ErrorMessage = "Durasi is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Durasi must be greater than 0")]
        public int Durasi { get; set; }

        [Required(ErrorMessage = "Tanggal is required")]
        [DataType(DataType.Date)]
        public DateTime Tanggal { get; set; }

        [Display(Name = "Status Pemesanan")]
        public string Status { get; set; }

        [Display(Name = "Nama Driver")]
        public string? DriverName { get; set; }

        [Required(ErrorMessage = "Start Mining is required")]
        [Display(Name = "Start Mining")]
        public int StartMiningId { get; set; }

        [Required(ErrorMessage = "End Mining is required")]
        [Display(Name = "End Mining")]
        public int EndMiningId { get; set; }

        [Required(ErrorMessage = "Employee is required")]
        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Vehicle is required")]
        [Display(Name = "Vehicle")]
        public int VehicleId { get; set; }

        public virtual Mining StartMining { get; set; }
        public virtual Mining EndMining { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual ICollection<ApprovalProcess> ApprovalProcesses { get; set; }
    }
}
