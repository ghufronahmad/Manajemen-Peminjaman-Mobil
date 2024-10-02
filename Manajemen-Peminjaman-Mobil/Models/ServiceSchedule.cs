namespace Manajemen_Peminjaman_Mobil.Models
{
    public class ServiceSchedule
    {
        public int Id { get; set; }
        public string Biaya { get; set; }
        public string Keterangan { get; set; }
        public DateTime Tanggal_Service { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
