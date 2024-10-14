using ASP_DangKiThi.Models;
using ASP_DangKiThi.Utiltity;
using Microsoft.AspNetCore.Mvc;

namespace ASP_DangKiThi.Controllers
{
    public class BaseController : Controller
    {
        //Db
        protected CService objService { get; }

        public BaseController(
            CService objService)
        {
            this.objService = objService;
        }

        public int AutoID { get; set; } = 0;

        protected bool blIsUpdate = false;

        public IActionResult SaveData<T>(T objRequest, string strViewInstance, string strViewTo)
        {
            if (ModelState.IsValid == true)
            {
                try
                {
                    if (blIsUpdate == true)
                        UpdateData_Entry(objRequest);
                    else
                        AddData_Entry(objRequest);

                    return RedirectToAction(strViewTo);
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

            return View(strViewInstance, objRequest);
        }

        protected virtual void AddData_Entry<T>(T objRequest)
        {

        }

        protected virtual void UpdateData_Entry<T>(T objRequest)
        {

        }

    }
}
