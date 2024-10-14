using ASP_DangKiThi.Models;
using ASP_DangKiThi.Models.CustomModels;
using ASP_DangKiThi.Utiltity;
using Microsoft.AspNetCore.Mvc;

namespace ASP_DangKiThi.Controllers
{
    public class AccountController : BaseController
    {
        public AccountController(CService objService) : base(objService)
        {

        }

        #region View
        public IActionResult LoginView()
        {
            //Check session
            // Kiểm tra mã đăng nhập trong session
            string strMaDangNhap = CCommon.GetMaDangNhapSession(objService.HttpContextAccessor);

            if (strMaDangNhap != "")
                // Đăng nhập thành công, chuyển hướng về trang chính
                return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult AccountViewList()
        {
            // Khởi tạo danh sách các AccountModel
            List<Account> arrDB = objService.DbContext.Accounts.Where(it => it.Deleted == 0).ToList();
            List<AccountModel> arrRes = new();

            // Ánh xạ từng đối tượng trong arrDB sang arrRes
            foreach (Account objAccount in arrDB)
            {
                AccountModel objAccountModel = new();
                CUtility.AssignProperties(objAccount, objAccountModel);
                arrRes.Add(objAccountModel);
            }

            // Trả về view với danh sách các tài khoản
            return View(arrRes);
        }

        public IActionResult AccountViewDetail(int iID)
        {
            Account objRes = new();
            // Khởi tạo danh sách các AccountModel
            Account objDB = objService.DbContext.Accounts.FirstOrDefault(it => it.AutoId == iID);
            if (objDB != null)
            {
                CUtility.AssignProperties(objDB, objRes);
            }

            // Trả về view với danh sách các tài khoản
            return View(objRes);
        }

        public IActionResult AccountViewEdit(int iID)
        {
            AccountModel objRes = new();
            // Khởi tạo danh sách các AccountModel
            Account objDB = objService.DbContext.Accounts.FirstOrDefault(it => it.AutoId == iID);
            if (objDB != null)
            {
                CUtility.AssignProperties(objDB, objRes);
            }

            // Trả về view với danh sách các tài khoản
            return View(objRes);
        }
        public IActionResult Logout()
        {
            if (ModelState.IsValid == true)
            {
                try
                {
                    //Xóa session đi
                    CCommon.DeleteMaDangNhapSession(objService.HttpContextAccessor);

                    // Chuyển hướng về trang login
                    return View("LoginView");
                }
                catch (Exception ex)
                {
                    // Nếu tài khoản đăng nhập không hợp lệ, thêm thông báo lỗi
                    ModelState.AddModelError(CCommon.MessageValue, ex.Message);
                }
            }
            else // Nếu vào trường hợp này thì check all data
            {
                // Kiểm tra và in lỗi nếu có
                foreach (var objError in ModelState.Values.SelectMany(v => v.Errors))
                    ModelState.AddModelError(CCommon.MessageValue, objError.ErrorMessage);
            }

            // Nếu có lỗi trong form, trả lại view với ModelState chứa thông báo lỗi
            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region Nhóm override
        protected override void AddData_Entry<AccountModel>(AccountModel objRequest)
        {

        }

        protected override void UpdateData_Entry<AccountModel>(AccountModel objRequest)
        {

        }

        #endregion

        #region Các action cho form
        [HttpPost]
        public IActionResult Login(AccountModel objModel)
        {
            if (ModelState.IsValid == true)
            {
                string strError = "";
                try
                {
                    if (objModel.AccountName == "")
                        strError += "Vui lòng nhập mã đăng nhập.";

                    if (objModel.AccountPassword == "")
                        strError += "Vui lòng nhập mật khẩu.";

                    if (strError != "")
                        throw new Exception(strError);

                    // Kiểm tra tài khoản tồn tại
                    Account objCheck = objService.DbContext.Accounts.FirstOrDefault(it => it.AccountName == objModel.AccountName);
                    if (objCheck == null || objCheck.Deleted == 1)
                        throw new Exception("Mã đăng nhập không tồn tại.");

                    //Kiểm tra mật khẩu
                    if (objModel.AccountPassword != objCheck.AccountPassword)
                        throw new Exception("Mật khẩu không chính xác.");

                    //Set session
                    CCommon.SetMaDangNhapSession(objService.HttpContextAccessor, objCheck.AccountName);

                    // Đăng nhập thành công, chuyển hướng về trang chính
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    // Nếu tài khoản đăng nhập không hợp lệ, thêm thông báo lỗi
                    ModelState.AddModelError(CCommon.MessageValue, ex.Message);
                }
            }
            else // Nếu vào trường hợp này thì check all data
            {
                // Kiểm tra và in lỗi nếu có
                foreach (var objError in ModelState.Values.SelectMany(v => v.Errors))
                    ModelState.AddModelError(CCommon.MessageValue, objError.ErrorMessage);
            }

            // Nếu có lỗi trong form, trả lại view với ModelState chứa thông báo lỗi
            return View("LoginView", objModel);
        }

        [HttpPost]
        public IActionResult SaveData(AccountModel objRequest)
        {
            return base.SaveData(objRequest, "AccountManagementListView", "AccountManagementEditView");
        }

        #endregion
    }
}
