namespace Manajemen_Peminjaman_Mobil.Models.Domain
{
    public class Region
    {
        public int Id
        {
            get; set;
        }
        public string Region_Name
        {
            get; set;
        }
        public ICollection<Mining> Minings { get; set; }
    } 
}
