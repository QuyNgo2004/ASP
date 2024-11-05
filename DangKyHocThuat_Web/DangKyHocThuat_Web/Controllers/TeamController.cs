using DangKyHocThuat_Web.Models;
using Microsoft.AspNetCore.Mvc;
using X.PagedList.Extensions;
using X.PagedList;

namespace DangKyHocThuat_Web.Controllers
{
    public class TeamController : Controller
    {
        private readonly db_ASP_ProjectContext _context;

        public TeamController(db_ASP_ProjectContext context)
        {
            _context = context;
        }

        #region Các view
        public IActionResult List(int? p_iPage)
        {
            IPagedList<Team> v_arrData = new List<Team>().ToPagedList(1, 10);
            try
            {
                v_arrData = _context.Teams
              .Where(it => it.Deleted == 0)
              .OrderBy(p => p.TeamName) // Thêm sắp xếp để có kết quả nhất quán
              .ToPagedList(p_iPage ?? 1, 10);// Phân trang với trang mặc định là 1
            }
            catch (Exception ex)
            {
                // Adds an error to the ModelState
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(v_arrData);

        }

        public IActionResult Edit(int id)
        {
            Team v_objData = new Team();
            try
            {
                v_objData = _context.Teams.FirstOrDefault(it => it.AutoId == id);
                if (v_objData == null)
                    v_objData = new Team();
            }
            catch (Exception ex)
            {
                // Adds an error to the ModelState
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(v_objData);
        }

        public IActionResult Detail(int id)
        {
            Team v_objData = new Team();
            try
            {
                v_objData = _context.Teams.FirstOrDefault(it => it.AutoId == id);
            }
            catch (Exception ex)
            {
                // Adds an error to the ModelState
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(v_objData);
        }

        public IActionResult Delete(int id)
        {
            Team v_objData = new Team();
            try
            {
                v_objData = _context.Teams.FirstOrDefault(it => it.AutoId == id);

                if (v_objData != null)
                {
                    v_objData.Deleted = 1;
                    v_objData.UpdatedBy = "tuantm";
                    v_objData.UpdatedAt = DateTime.Now;

                    _context.Teams.Update(v_objData);
                    _context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                // Adds an error to the ModelState
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            // Điều hướng trở lại danh sách giảng viên
            return RedirectToAction("List");
        }
        #endregion

        #region Sự kiện nhấn form lưu

        [HttpPost]
        public IActionResult Save_Data(Team p_objRequest)
        {
            try
            {
                if (p_objRequest.AutoId != 0)
                    Update_Data(p_objRequest);
                else
                    Add_Data(p_objRequest);

                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View("Edit", p_objRequest);
        }

        private void Update_Data(Team p_objRequest)
        {
            if (p_objRequest.TeamName.Trim() == "")
                throw new Exception("Tên phòng không được để trống");

            Team v_objCheck = _context.Teams.FirstOrDefault(it => it.AutoId != p_objRequest.AutoId &&
            it.TeamName.Trim() == p_objRequest.TeamName.Trim() && it.Deleted == 0);

            if (v_objCheck != null)
                throw new Exception("Tên phòng đã tồn tại.");

            p_objRequest.UpdatedBy = "tuantm";
            p_objRequest.UpdatedAt = DateTime.Now;

            _context.Teams.Update(p_objRequest);
            _context.SaveChanges();
        }

        private void Add_Data(Team p_objRequest)
        {

            if (p_objRequest.TeamName.Trim() == "")
                throw new Exception("Tên phòng không được để trống");

            Team v_objCheck = _context.Teams.FirstOrDefault(it => it.TeamName.Trim() == p_objRequest.TeamName.Trim() && it.Deleted == 0);

            if (v_objCheck != null)
                throw new Exception("Tên phòng đã tồn tại.");

            p_objRequest.Deleted = 0;
            p_objRequest.CreatedBy = "tuantm";
            p_objRequest.CreatedAt = DateTime.Now;
            p_objRequest.UpdatedBy = "tuantm";
            p_objRequest.UpdatedAt = DateTime.Now;

            _context.Teams.Add(p_objRequest);
            _context.SaveChanges();
        }

        #endregion
    }
}
