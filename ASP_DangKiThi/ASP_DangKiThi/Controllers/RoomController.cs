using Microsoft.AspNetCore.Mvc;
using ASP_DangKiThi.Models;

namespace ASP_DangKiThi.Controllers
{
    public class RoomController : BaseController
    {
        public RoomController(db_ASP_ProjectContext objDBContext) : base(objDBContext)
        {
        }

        #region Views
        public IActionResult ListView()
        {
            List<Room> listRoom = this.objDBContext.Rooms.Where(rm => rm.Deleted == 0).ToList();
            return View(listRoom);
        }

        public IActionResult DetailsView()
        {
            return View();
        }

        public IActionResult EditView(int id)
        {
            Room rm = objDBContext.Rooms.SingleOrDefault(rm => rm.AutoId == id);
            if (rm != null)
            {
                return View(rm);
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
        //protected override void AddData_Entry<Room>(Room rm)
        //{
        //    objDBContext.Rooms.Add(rm);
        //    objDBContext.SaveChanges();
        //    RedirectToAction("ListView");
        //}
        //protected override void UpdateData_Entry<Room>(Room rm)
        //{
        //    objDBContext.Rooms.Update(rm);
        //    objDBContext.SaveChanges();
        //    RedirectToAction("ListView");
        //}
        [HttpPost]
        public IActionResult AddData(Room rm)
        {
            rm.Deleted = 0;
            rm.UpdatedAt = DateTime.Now;
            rm.CreatedAt = DateTime.Now;
            rm.CreatedBy = "admin";
            rm.UpdatedBy = "admin";
            objDBContext.Rooms.Add(rm);
            objDBContext.SaveChanges();
            return RedirectToAction("ListView");
        }
        [HttpPost]
        public void UpdateData(Room rm)
        {
            objDBContext.Rooms.Update(rm);
            objDBContext.SaveChanges();
            RedirectToAction("ListView");
        }
        [HttpPost]
        protected override void DeleteData_Entry(int id)
        {
            Room rm = objDBContext.Rooms.SingleOrDefault(rm=>rm.AutoId == id);
            if(rm != null)
            {
                objDBContext.Rooms.Remove(rm);
                objDBContext.SaveChanges();
            }
            RedirectToAction("ListView");
        }
        #endregion
    }
}
