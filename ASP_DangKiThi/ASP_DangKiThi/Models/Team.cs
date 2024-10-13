namespace ASP_DangKiThi.Models
{
    public partial class Team
    {
        public Team()
        {
            ExamRegisters = new HashSet<ExamRegister>();
            Students = new HashSet<Student>();
        }

        public int AutoId { get; set; }
        public string TeamName { get; set; } = null!;
        public int Deleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; } = null!;

        public virtual ICollection<ExamRegister> ExamRegisters { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
