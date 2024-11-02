using System;
using System.Collections.Generic;

namespace DangKyHocThuat_Web.Models
{
    public partial class Room
    {
        public Room()
        {
            Exams = new HashSet<Exam>();
        }

        public int AutoId { get; set; }
        public string RoomName { get; set; } = null!;
        public int Deleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; } = null!;

        public virtual ICollection<Exam> Exams { get; set; }
    }
}
