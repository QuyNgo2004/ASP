namespace DangKyHocThuat_Web.Models.ViewModels
{
    public class ClassViewModel
    {
        public int AutoId { get; set; } = 0;
        public string ClassName { get; set; } = "";
        public int ProfessorId { get; set; } = 0;
        public int Deleted { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = new DateTime();
        public string CreatedBy { get; set; } = "";
        public DateTime UpdatedAt { get; set; } = new DateTime();
        public string UpdatedBy { get; set; } = "";

        public List<Professor> Professors { get; set; } = new List<Professor>();
    }
}
