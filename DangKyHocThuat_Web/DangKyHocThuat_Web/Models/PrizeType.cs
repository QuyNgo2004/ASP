using System;
using System.Collections.Generic;

namespace DangKyHocThuat_Web.Models
{
    public partial class PrizeType
    {
        public PrizeType()
        {
            PrizeRegisters = new HashSet<PrizeRegister>();
        }

        public int AutoId { get; set; }
        public string PrizeTypeName { get; set; } = null!;
        public int Deleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; } = null!;

        public virtual ICollection<PrizeRegister> PrizeRegisters { get; set; }
    }
}
