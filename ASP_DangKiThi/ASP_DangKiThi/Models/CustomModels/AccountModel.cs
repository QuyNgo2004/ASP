namespace ASP_DangKiThi.Models.CustomModels
{
    public class AccountModel : BaseModel
    {

        private string strAccountName = "";
        private string strAccountPassword = "";
        private int iPersonalId = 0;


        public AccountModel() : base()
        {
            strAccountName = "";
            strAccountPassword = "";
            iPersonalId = 0;
        }

        public string AccountName
        {
            get
            {
                return strAccountName;
            }
            set
            {
                if (value != null)
                    strAccountName = value.Trim();
            }
        }

        public string AccountPassword
        {
            get
            {
                return strAccountPassword;
            }
            set
            {
                if (value != null)
                    strAccountPassword = value.Trim();
            }
        }

        public int PersonalId { get => iPersonalId; set => iPersonalId = value; }
    }
}
