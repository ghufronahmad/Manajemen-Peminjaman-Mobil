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

        [NotMapped]
        public Mining StartMining { get; set; }

        [NotMapped]
        public Mining EndMining { get; set; }

        [NotMapped]
        public Employee Employee { get; set; }

        [NotMapped]
        public Vehicle Vehicle { get; set; }
    }
}
