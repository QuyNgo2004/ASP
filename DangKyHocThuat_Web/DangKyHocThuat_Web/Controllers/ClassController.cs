using DangKyHocThuat_Web.Models;
using Microsoft.AspNetCore.Mvc;
using X.PagedList.Extensions;
using X.PagedList;
using Microsoft.AspNetCore.Mvc.Rendering;
using DangKyHocThuat_Web.Models.ViewModels;

namespace DangKyHocThuat_Web.Controllers
{
    public class ClassController : Controller
    {
        private readonly db_ASP_ProjectContext _context;

        public ClassController(db_ASP_ProjectContext context)
        {
            _context = context;
        }

        #region Các view
        public IActionResult List(int? p_iPage)
        {
            IPagedList<Class> v_arrData = new List<Class>().ToPagedList(1, 10);
            try
            {
                v_arrData = _context.Classes
              .Where(it => it.Deleted == 0)
              .OrderBy(p => p.ClassName) // Thêm sắp xếp để có kết quả nhất quán
              .ToPagedList(p_iPage ?? 1, 10);// Phân trang với trang mặc định là 1

                foreach (Class v_objItem in v_arrData)
                {
                    v_objItem.Professor = _context.Professors.FirstOrDefault(it => it.AutoId == v_objItem.ProfessorId);

                    if (v_objItem.Professor == null)
                        v_objItem.Professor = new Professor();
                }
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
            ClassViewModel v_objData = new ClassViewModel();
            try
            {
                Class v_objEdit = _context.Classes.FirstOrDefault(it => it.AutoId == id);
                if (v_objEdit == null)
                    v_objEdit = new Class();

                v_objData.AutoId = v_objEdit.AutoId;
                v_objData.ClassName = v_objEdit.ClassName;
                v_objData.ProfessorId = v_objEdit.ProfessorId;
                v_objData.Deleted = v_objEdit.Deleted;
                v_objData.CreatedAt = v_objEdit.CreatedAt;
                v_objData.CreatedBy = v_objEdit.CreatedBy;
                v_objData.UpdatedAt = v_objEdit.UpdatedAt;
                v_objData.UpdatedBy = v_objEdit.UpdatedBy;

                //Combobox professor
                v_objData.Professors = _context.Professors.ToList();
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
            Class v_objData = new Class();
            try
            {
                v_objData = _context.Classes.FirstOrDefault(it => it.AutoId == id);
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
            Class v_objData = new Class();
            try
            {
                v_objData = _context.Classes.FirstOrDefault(it => it.AutoId == id);

                if (v_objData != null)
                {
                    v_objData.Deleted = 1;
                    v_objData.UpdatedBy = "tuantm";
                    v_objData.UpdatedAt = DateTime.Now;

                    _context.Classes.Update(v_objData);
                    _context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                // Adds an error to the ModelState
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return RedirectToAction("List");
        }
        #endregion

        #region Sự kiện nhấn form lưu

        [HttpPost]
        public IActionResult Save_Data(ClassViewModel p_objRequest)
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

        private void Update_Data(ClassViewModel p_objRequest)
        {
            if (p_objRequest.ClassName.Trim() == "")
                throw new Exception("Mã lớp không được để trống.");

            if (p_objRequest.ProfessorId == 0)
                throw new Exception("Vui lòng chọn giảng viên.");

            Class v_objCheck = _context.Classes.FirstOrDefault(it => it.AutoId != p_objRequest.AutoId &&
            it.ClassName == p_objRequest.ClassName && it.Deleted == 0);

            if (v_objCheck != null)
                throw new Exception("Lớp đã tồn tại.");

            p_objRequest.UpdatedBy = "tuantm";
            p_objRequest.UpdatedAt = DateTime.Now;

            Class v_objData = new Class();
            v_objData.AutoId = p_objRequest.AutoId;
            v_objData.ClassName = p_objRequest.ClassName;
            v_objData.ProfessorId = p_objRequest.ProfessorId;
            v_objData.Deleted = p_objRequest.Deleted;
            v_objData.CreatedAt = p_objRequest.CreatedAt;
            v_objData.CreatedBy = p_objRequest.CreatedBy;
            v_objData.UpdatedAt = p_objRequest.UpdatedAt;
            v_objData.UpdatedBy = p_objRequest.UpdatedBy;

            _context.Classes.Update(v_objData);
            _context.SaveChanges();
        }

        private void Add_Data(ClassViewModel p_objRequest)
        {
            if (p_objRequest.ClassName.Trim() == "")
                throw new Exception("Mã lớp không được để trống.");

            if (p_objRequest.ProfessorId == 0)
                throw new Exception("Vui lòng chọn giảng viên.");


            Class v_objCheck = _context.Classes.FirstOrDefault(it => it.ClassName == p_objRequest.ClassName && it.Deleted == 0);

            if (v_objCheck != null)
                throw new Exception("Lớp đã tồn tại.");

            p_objRequest.UpdatedBy = "tuantm";
            p_objRequest.UpdatedAt = DateTime.Now;

            Class v_objData = new Class();
            v_objData.AutoId = p_objRequest.AutoId;
            v_objData.ClassName = p_objRequest.ClassName;
            v_objData.ProfessorId = p_objRequest.ProfessorId;
            v_objData.Deleted = p_objRequest.Deleted;
            v_objData.CreatedAt = DateTime.Now;
            v_objData.CreatedBy = "tuantm";
            v_objData.UpdatedAt = DateTime.Now;
            v_objData.UpdatedBy = "tuantm";

            _context.Classes.Add(v_objData);
            _context.SaveChanges();
        }

        #endregion

        private List<SelectListItem> ListProfessors()
        {
            List<SelectListItem> v_arrRes = new List<SelectListItem>();

            List<Professor> v_arrProfessor = _context.Professors.ToList();
            foreach (Professor v_objItem in v_arrProfessor)
            {
                SelectListItem v_objItem_Combo = new SelectListItem(text: v_objItem.ProfessorId + '|' + v_objItem.ProfessorEmail,
                    value: v_objItem.AutoId.ToString());

                v_arrRes.Add(v_objItem_Combo);
            }

            return v_arrRes;
        }
    }
}
