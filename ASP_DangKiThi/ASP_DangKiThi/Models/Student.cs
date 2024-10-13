namespace ASP_DangKiThi.Models
{
    public partial class Student
    {
        public Student()
        {
            Accounts = new HashSet<Account>();
        }

        public int AutoId { get; set; }
        public string StudentId { get; set; } = null!;
        public string StudentName { get; set; } = null!;
        public DateTime StudentDoB { get; set; }
        public string StudentPoB { get; set; } = null!;
        public int ClassId { get; set; }
        public int TeamId { get; set; }
        public int Deleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; } = null!;

        public virtual Class Class { get; set; } = null!;
        public virtual Team Team { get; set; } = null!;
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
