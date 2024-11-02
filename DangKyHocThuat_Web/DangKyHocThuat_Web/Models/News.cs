using System;
using System.Collections.Generic;

namespace DangKyHocThuat_Web.Models
{
    public partial class News
    {
        public int AutoId { get; set; }
        public string NewsTitle { get; set; } = null!;
        public string NewsContent { get; set; } = null!;
        public int Deleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; } = null!;
    }
}
