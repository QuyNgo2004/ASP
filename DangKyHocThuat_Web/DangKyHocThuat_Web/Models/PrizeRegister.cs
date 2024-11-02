using System;
using System.Collections.Generic;

namespace DangKyHocThuat_Web.Models
{
    public partial class PrizeRegister
    {
        public int AutoId { get; set; }
        public int PrizeTypeId { get; set; }
        public int PrizeValue { get; set; }
        public int ExamId { get; set; }
        public int TeamId { get; set; }
        public int Deleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; } = null!;

        public virtual Exam Exam { get; set; } = null!;
        public virtual PrizeType PrizeType { get; set; } = null!;
        public virtual Team Team { get; set; } = null!;
    }
}
