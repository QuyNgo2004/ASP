using System;
using System.Collections.Generic;

namespace DangKyHocThuat_Web.Models
{
    public partial class Exam
    {
        public Exam()
        {
            ExamProctors = new HashSet<ExamProctor>();
            ExamRegisters = new HashSet<ExamRegister>();
            PrizeRegisters = new HashSet<PrizeRegister>();
        }

        public int AutoId { get; set; }
        public string ExamId { get; set; } = null!;
        public string ExamName { get; set; } = null!;
        public DateTime ExamStartDate { get; set; }
        public DateTime ExamEndDate { get; set; }
        public int ExamTeamMaxCapacity { get; set; }
        public int RoomId { get; set; }
        public int Deleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; } = null!;

        public virtual Room Room { get; set; } = null!;
        public virtual ICollection<ExamProctor> ExamProctors { get; set; }
        public virtual ICollection<ExamRegister> ExamRegisters { get; set; }
        public virtual ICollection<PrizeRegister> PrizeRegisters { get; set; }
    }
}
