using ASP_DangKiThi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_DangKiThi.Controllers
{
    public class ClassController : BaseController
    {
        // Constructor
        public ClassController(db_ASP_ProjectContext objDBContext) : base(objDBContext)
        {
        }

        #region Views
        public IActionResult ListView()
        {
            List<Class> listClass = this.objDBContext.Classes.Where(cl => cl.Deleted == 0).ToList();
            return View(listClass);
        }

        public IActionResult DetailsView()
        {
            return View();
        }

        public IActionResult EditView(int id)
        {
            Class cl = objDBContext.Classes.SingleOrDefault(cl => cl.AutoId == id);
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
