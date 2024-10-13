namespace ASP_DangKiThi.Models.CustomModels
{
    public class BaseModel
    {
        private int iAutoID = 0;
        private int iDeleted = 0;
        private DateTime? dtmCreatedAt = null;
        private string strCreatedBy = "";
        private DateTime? dtmUpdatedAt = null;
        private string strUpdatedBy = "";

        public BaseModel()
        {
            iAutoID = 0;
            iDeleted = 0;
            dtmCreatedAt = null;
            strCreatedBy = "";
            dtmUpdatedAt = null;
            strUpdatedBy = "";
        }

        public int AutoID { get => iAutoID; set => iAutoID = value; }

        public int Deleted { get => iDeleted; set => iDeleted = value; }
        public DateTime? CreatedAt { get => dtmCreatedAt; set => dtmCreatedAt = value; }
        public string CreatedBy { get => strCreatedBy; set => strCreatedBy = value.Trim(); }
        public DateTime? UpdatedAt { get => dtmUpdatedAt; set => dtmUpdatedAt = value; }
        public string UpdatedBy { get => strUpdatedBy; set => strUpdatedBy = value.Trim(); }
    }
}
