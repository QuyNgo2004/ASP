using System;
using System.Collections.Generic;

namespace DangKyHocThuat_Web.Models
{
    public partial class Account
    {
        public int AutoId { get; set; }
        public string AccountName { get; set; } = null!;
        public string AccountPassword { get; set; } = null!;
        public int PersonalId { get; set; }
        public int Deleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; } = null!;

        public virtual Professor Personal { get; set; } = null!;
        public virtual Student PersonalNavigation { get; set; } = null!;
    }
}
