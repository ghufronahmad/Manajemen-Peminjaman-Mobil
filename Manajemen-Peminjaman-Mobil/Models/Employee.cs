using Manajemen_Peminjaman_Mobil.Models.Domain;

namespace Manajemen_Peminjaman_Mobil.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone_Number { get; set; }
        public DateTime Tanggal_Lahir {  get; set; }
        public int OfficeId { get; set; }
        public Office Office { get; set; }
        public int EmployeePositionId { get; set; }
        public EmployeePosition Position { get; set; }
    }
}
