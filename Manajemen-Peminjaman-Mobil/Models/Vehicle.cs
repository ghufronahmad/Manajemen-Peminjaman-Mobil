namespace Manajemen_Peminjaman_Mobil.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Plat_Nomor { get; set; }
        public Tipe Type { get; set; }
        public string Tahun_Kendaraan { get; set; }
        public Status Status_Kepemilikan { get; set; }

    }
    public enum Tipe
    {
        Personal,
        Barang
    }
    public enum Status
    {
        Perusahaan,
        Sewa
    }
}
