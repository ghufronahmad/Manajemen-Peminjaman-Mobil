using Manajemen_Peminjaman_Mobil.Models.Domain;

namespace Manajemen_Peminjaman_Mobil.Models
{
    public class ApprovalProcess
    {
        public int Id { get; set; }
        public StatusApproval Status { get; set; }
        public DateTime Approved_At { get; set; }
        public DateTime Rejected_At { get; set; }
        public int VehicleBookingId { get; set; }
        public VehicleBooking VehicleBooking { get; set; }
        public int ApprovalLevelId { get; set; }
        public ApprovalLevel ApprovalLevel { get; set; }
        public int ApproverId { get; set; }
        public Approver Approver { get; set; }
    }
    
    public enum StatusApproval
    {
        Menunggu,
        Disetujui,
        Ditolak
    }
}
