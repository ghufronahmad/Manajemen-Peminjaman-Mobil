using Microsoft.AspNetCore.Identity;

namespace Manajemen_Peminjaman_Mobil.Models.Domain
{
    public class User : IdentityUser<Guid>
    {
        public string Name { get; set; }
    }
}
