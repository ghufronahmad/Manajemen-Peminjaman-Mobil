namespace Manajemen_Peminjaman_Mobil.Models
{
    public class FuelConsumption
    {
        public int Id { get; set; }
        public int Odometer { get; set; }
        public int Biaya {  get; set; }
        public string Keterangan { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
