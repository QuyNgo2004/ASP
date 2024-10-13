namespace ASP_DangKiThi.Models
{
    public partial class ExamRegister
    {
        public int AutoId { get; set; }
        public int TeamId { get; set; }
        public int ExamId { get; set; }
        public int Deleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; } = null!;

        public virtual Exam Exam { get; set; } = null!;
        public virtual Team Team { get; set; } = null!;
    }
}
