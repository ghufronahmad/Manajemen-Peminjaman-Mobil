namespace Manajemen_Peminjaman_Mobil.Models.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }

    public enum Role
    {
        Admin,
        Approver
    }
}
