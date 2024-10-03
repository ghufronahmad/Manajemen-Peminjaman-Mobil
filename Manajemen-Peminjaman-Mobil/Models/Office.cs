using System.Collections;
using Manajemen_Peminjaman_Mobil.Models.Domain;

namespace Manajemen_Peminjaman_Mobil.Models
{
    public class Office
    {
        public int Id { get; set; }
        public string Office_Name { get; set; }
        public int RegionId { get; set; }
        public Region Region { get; set; }
        public Unit Unit { get; set; }

        //public ICollection<Region> Regions { get; set; }

    }

    public enum Unit
    {
        Cabang,
        Pusat
    }
}
