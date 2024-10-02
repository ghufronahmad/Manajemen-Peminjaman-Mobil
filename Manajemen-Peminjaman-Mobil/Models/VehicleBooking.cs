using Manajemen_Peminjaman_Mobil.Models.Domain;
using Microsoft.Identity.Client;

namespace Manajemen_Peminjaman_Mobil.Models
{
    public class VehicleBooking
    {
        public int Id { get; set; }
        public string Keperluan { get; set; }
        public int Durasi {  get; set; }
        public DateTime Tanggal { get; set; }
        public int StartMiningId { get; set; }
        public int EndMiningId { get; set; }
        public Mining Mining { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
