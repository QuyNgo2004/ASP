using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DangKyHocThuat_Web.Models;
using X.PagedList.Extensions;
using X.PagedList;

namespace DangKyHocThuat_Web.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly db_ASP_ProjectContext _context;

        public ProfessorController(db_ASP_ProjectContext context)
        {
            _context = context;
        }

        #region Các view
        public IActionResult List(int? p_iPage)
        {
            IPagedList<Professor> v_arrData = new List<Professor>().ToPagedList(1, 10);

            try
            {
                v_arrData = _context.Professors
             .Where(it => it.Deleted == 0)
             .OrderBy(p => p.ProfessorId) // Thêm sắp xếp để có kết quả nhất quán
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
            Professor v_objData = new Professor();
            try
            {
                v_objData = _context.Professors.FirstOrDefault(it => it.AutoId == id);
                if (v_objData == null)
                    v_objData = new Professor();
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
            Professor v_objData = new Professor();
            try
            {
                v_objData = _context.Professors.FirstOrDefault(it => it.AutoId == id);
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
            Professor v_objData = new Professor();
            try
            {
                v_objData = _context.Professors.FirstOrDefault(it => it.AutoId == id);

                if (v_objData != null)
                {
                    v_objData.Deleted = 1;
                    v_objData.UpdatedBy = "tuantm";
                    v_objData.UpdatedAt = DateTime.Now;

                    _context.Professors.Update(v_objData);
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
        public IActionResult Save_Data(Professor p_objRequest)
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

        private void Update_Data(Professor p_objRequest)
        {
            if (p_objRequest.ProfessorId.Trim() == "")
                throw new Exception("Mã giảng viên không được để trống");

            if (p_objRequest.ProfessorName.Trim() == "")
                throw new Exception("Tên giảng viên không được để trống");

            if (p_objRequest.ProfessorEmail.Trim() == "")
                throw new Exception("Email không được để trống");

            Professor v_objCheck = _context.Professors.FirstOrDefault(it => it.AutoId != p_objRequest.AutoId &&
            it.ProfessorId == p_objRequest.ProfessorId && it.Deleted == 0);

            if (v_objCheck != null)
                throw new Exception("Mã giảng viên đã tồn tại.");

            p_objRequest.UpdatedBy = "tuantm";
            p_objRequest.UpdatedAt = DateTime.Now;

            _context.Professors.Update(p_objRequest);
            _context.SaveChanges();
        }

        private void Add_Data(Professor p_objRequest)
        {
            if (p_objRequest.ProfessorId.Trim() == "")
                throw new Exception("Mã giảng viên không được để trống");

            if (p_objRequest.ProfessorName.Trim() == "")
                throw new Exception("Tên giảng viên không được để trống");

            if (p_objRequest.ProfessorEmail.Trim() == "")
                throw new Exception("Email không được để trống");

            Professor v_objCheck = _context.Professors.FirstOrDefault(it => it.ProfessorId == p_objRequest.ProfessorId && it.Deleted == 0);

            if (v_objCheck != null)
                throw new Exception("Mã giảng viên đã tồn tại.");

            p_objRequest.Deleted = 0;
            p_objRequest.CreatedBy = "tuantm";
            p_objRequest.CreatedAt = DateTime.Now;
            p_objRequest.UpdatedBy = "tuantm";
            p_objRequest.UpdatedAt = DateTime.Now;

            _context.Professors.Add(p_objRequest);
            _context.SaveChanges();
        }

        #endregion
    }
}
