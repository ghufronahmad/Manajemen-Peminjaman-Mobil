namespace Manajemen_Peminjaman_Mobil.Models.Domain
{
    public class Mining
    {
        public int Id { get; set; }
        public string Mining_Name { get; set; }
        public int RegionId { get; set; }
        public Region Region { get; set; }
    }
}
