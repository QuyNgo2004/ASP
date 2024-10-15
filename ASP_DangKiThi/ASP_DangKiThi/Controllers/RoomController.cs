using Microsoft.AspNetCore.Mvc;
using ASP_DangKiThi.Models;
using ASP_DangKiThi.Utiltity;

namespace ASP_DangKiThi.Controllers
{
    public class RoomController : BaseController
    {
        public RoomController(CService objService) : base(objService)
        {
        }

        #region Views
        public IActionResult ListView()
        {
            List<Room> listRoom = this.objService.DbContext.Rooms.Where(rm => rm.Deleted == 0).ToList();
            return View(listRoom);
        }

        public IActionResult DetailsView()
        {
            return View();
        }

        public IActionResult EditView(int id)
        {
            Room rm = objService.DbContext.Rooms.SingleOrDefault(rm => rm.AutoId == id);
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
        //    objService.DbContext.Rooms.Add(rm);
        //    objService.DbContext.SaveChanges();
        //    RedirectToAction("ListView");
        //}
        //protected override void UpdateData_Entry<Room>(Room rm)
        //{
        //    objService.DbContext.Rooms.Update(rm);
        //    objService.DbContext.SaveChanges();
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
            objService.DbContext.Rooms.Add(rm);
            objService.DbContext.SaveChanges();
            return RedirectToAction("ListView");
        }
        [HttpPost]
        public void UpdateData(Room rm)
        {
            objService.DbContext.Rooms.Update(rm);
            objService.DbContext.SaveChanges();
            RedirectToAction("ListView");
        }
        [HttpPost]
        protected override void DeleteData_Entry(int id)
        {
            Room rm = objService.DbContext.Rooms.SingleOrDefault(rm=>rm.AutoId == id);
            if(rm != null)
            {
                objService.DbContext.Rooms.Remove(rm);
                objService.DbContext.SaveChanges();
            }
            RedirectToAction("ListView");
        }
        #endregion
    }
}
