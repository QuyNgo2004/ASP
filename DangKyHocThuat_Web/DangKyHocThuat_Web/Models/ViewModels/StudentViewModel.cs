namespace DangKyHocThuat_Web.Models.ViewModels
{
    public class StudentViewModel
    {
        public int AutoId { get; set; } = 0;
        public string StudentId { get; set; } ="";
        public string StudentName { get; set; } = "";
        public DateTime StudentDoB { get; set; } = DateTime.Now;
        public string StudentPoB { get; set; } = "";
        public int ClassId { get; set; } = 0;
        public int TeamId { get; set; } = 0;
        public int Deleted { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; } = "";
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public string UpdatedBy { get; set; } = "";

        public List<Class> Classes { get; set; } = null;
        public List<Team> Teams { get; set; } = null;

        public Class Class { get; set; } = null;
        public Team Team { get; set; } = null;

    }
}
