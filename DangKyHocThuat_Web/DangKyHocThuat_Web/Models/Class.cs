using System;
using System.Collections.Generic;

namespace DangKyHocThuat_Web.Models
{
    public partial class Class
    {
        public Class()
        {
            Students = new HashSet<Student>();
        }

        public int AutoId { get; set; }
        public string ClassName { get; set; } = null!;
        public int ProfessorId { get; set; }
        public int Deleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; } = null!;

        public virtual Professor Professor { get; set; } = null!;
        public virtual ICollection<Student> Students { get; set; }
    }
}
