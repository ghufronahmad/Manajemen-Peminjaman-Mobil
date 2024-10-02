using Microsoft.Identity.Client;

namespace Manajemen_Peminjaman_Mobil.Models.Domain
{
    public class ApprovalLevel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
    }
}
