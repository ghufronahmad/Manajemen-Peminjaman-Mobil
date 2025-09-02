namespace Manajemen_Peminjaman_Mobil.Models.Domain
{
    public class Approver
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public int ApprovalLevelId { get; set; }
        public ApprovalLevel ApprovalLevel { get; set; }
    }
}
