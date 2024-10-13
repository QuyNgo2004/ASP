using System.Text;

namespace ASP_DangKiThi.Utiltity
{
    public static class CCommon
    {
        public const string MessageValue = "strMessage";
        public static string SetTextErrorLabel(string strMessage)
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div class='alert alert-danger'>");
            sb.AppendLine(strMessage);
            sb.AppendLine("</div>");
            return sb.ToString();
        }
    }
}
