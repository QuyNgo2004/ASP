using ASP_DangKiThi.Models;
using ASP_DangKiThi.Utiltity;
using Microsoft.AspNetCore.Mvc;

namespace ASP_DangKiThi.Controllers
{
    public class ClassController : BaseController
    {
        // Constructor
        public ClassController(CService objService) : base(objService)
        {
        }

        #region Views
        public IActionResult ListView()
        {
            List<Class> listClass = this.objService.DbContext.Classes.Where(cl => cl.Deleted == 0).ToList();
            return View(listClass);
        }

        public IActionResult DetailsView()
        {
            return View();
        }

        public IActionResult EditView(int id)
        {
            Class cl = objService.DbContext.Classes.SingleOrDefault(cl => cl.AutoId == id);
            if (cl != null)
            {
                return View(cl);
            }
            else
            {
                return RedirectToAction("ListView");
            }
        }

        public IActionResult CreateView()
        {
            return View();
        }
        #endregion

        #region Actions

        #endregion
    }
}
