namespace Manajemen_Peminjaman_Mobil.Models.Domain
{
    public class Approver
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int DepartementId { get; set; }
        public Departement Departement { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
