namespace ASP_DangKiThi.Models
{
    public partial class Professor
    {
        public Professor()
        {
            Accounts = new HashSet<Account>();
            Classes = new HashSet<Class>();
            ExamProctors = new HashSet<ExamProctor>();
        }

        public int AutoId { get; set; }
        public string ProfessorId { get; set; } = null!;
        public string ProfessorName { get; set; } = null!;
        public string ProfessorEmail { get; set; } = null!;
        public string? ProfessorPhone { get; set; }
        public int Deleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; } = null!;

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<ExamProctor> ExamProctors { get; set; }
    }
}
