using Microsoft.AspNetCore.Http;
using System.Text;
using System.Text.Json;

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

        public static string GetSessionByKey(IHttpContextAccessor objHTTP, string strKey)
        {
            byte[] arrBytes = objHTTP.HttpContext.Session.Get(strKey);
            return arrBytes != null ? CUtility.ConvertByteArrayToString(arrBytes) : "";
        }

        public static void SetSession(IHttpContextAccessor objHTTP, string strKey, object objData)
        {
            if (objData == null)
                return;

            // Chuyển đổi đối tượng thành mảng byte
            byte[] arrBytes = JsonSerializer.SerializeToUtf8Bytes(objData);

            //Tạo đối tượng session
            ISession objSession = objHTTP.HttpContext.Session;

            // Lưu mảng byte vào session
            objSession.Set(strKey, arrBytes);
        }

        public static void DeleteSession(IHttpContextAccessor objHTTP, string strKey)
        {
            if (strKey.Trim() == "")
                return;

            objHTTP.HttpContext.Session.Remove(strKey);
        }

        public static string GetMaDangNhapSession(IHttpContextAccessor objHTTP)
        {
            return GetSessionByKey(objHTTP, "ASP_DangKyThi_Session");
        }

        public static void SetMaDangNhapSession(IHttpContextAccessor objHTTP, object objData)
        {
            SetSession(objHTTP, "ASP_DangKyThi_Session", objData);
        }

        public static void DeleteMaDangNhapSession(IHttpContextAccessor objHTTP)
        {
            DeleteSession(objHTTP, "ASP_DangKyThi_Session");
        }
    }
}
