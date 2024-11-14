using DangKyHocThuat_Web.Models;
using Microsoft.AspNetCore.Mvc;
using X.PagedList.Extensions;
using X.PagedList;
using DangKyHocThuat_Web.Models.ViewModels;
using DangKyHocThuat_Web.Utility;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DangKyHocThuat_Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly db_ASP_ProjectContext _context;

        public StudentController(db_ASP_ProjectContext context)
        {
            _context = context;
        }

        #region Các view
        public IActionResult List(int? p_iPage, int p_iClass_ID = 0, int p_iTeam_ID = 0)
        {
            IPagedList<StudentViewModel> v_arrData = new List<StudentViewModel>().ToPagedList(1, 10);
            try
            {
                List<Student> v_arrStudent = _context.Students.Where(it => it.Deleted == 0)
                                                              .OrderBy(p => p.CreatedAt).ToList();

                if (p_iClass_ID != 0)
                    v_arrStudent = v_arrStudent.Where(it => it.ClassId == p_iClass_ID).ToList();

                if (p_iTeam_ID != 0)
                    v_arrStudent = v_arrStudent.Where(it => it.TeamId == p_iTeam_ID).ToList();


                foreach (Student v_objStudent in v_arrStudent)
                {
                    StudentViewModel v_objItem = new StudentViewModel();
                    CUtility.Assign_Entity(v_objStudent, v_objItem);
                    v_arrData.Append(v_objItem);
                }

                v_arrData = v_arrData.ToPagedList(p_iPage ?? 1, 10);// Phân trang với trang mặc định là 1

                foreach (StudentViewModel v_objItem in v_arrData)
                {
                    v_objItem.Class = _context.Classes.FirstOrDefault(it => it.AutoId == v_objItem.ClassId);

                    if (v_objItem.Class == null)
                        v_objItem.Class = new Class();

                    v_objItem.Team = _context.Teams.FirstOrDefault(it => it.AutoId == v_objItem.TeamId);

                    if (v_objItem.Team == null)
                        v_objItem.Team = new Team();
                }

                List<Class> v_arrClass = _context.Classes.ToList();
                List<Team> v_arrTeam = _context.Teams.ToList();

                ViewBag.Classes = v_arrClass;
                ViewBag.Teams = v_arrTeam;

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
            StudentViewModel v_objData = new StudentViewModel();
            try
            {
                Student v_objEdit = _context.Students.FirstOrDefault(it => it.AutoId == id);
                if (v_objEdit == null)
                    v_objEdit = new Student();

                CUtility.Assign_Entity(v_objEdit, v_objData);

                ViewBag.Teams = new SelectList(_context.Teams.ToList(), "AutoId", "TeamName");
                ViewBag.Classes = new SelectList(_context.Teams.ToList(), "AutoId", "ClassName");
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
            Student v_objData = new Student();
            try
            {
                v_objData = _context.Students.FirstOrDefault(it => it.AutoId == id);

                if (v_objData != null)
                {
                    v_objData.Class = _context.Classes.FirstOrDefault(it => it.AutoId == v_objData.ClassId);
                    v_objData.Team = _context.Teams.FirstOrDefault(it => it.AutoId == v_objData.TeamId);
                }
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
            Student v_objData = new Student();
            try
            {
                v_objData = _context.Students.FirstOrDefault(it => it.AutoId == id);

                if (v_objData != null)
                {
                    v_objData.Deleted = 1;
                    v_objData.UpdatedBy = "tuantm";
                    v_objData.UpdatedAt = DateTime.Now;

                    _context.Students.Update(v_objData);
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

        // Optional Tim_Kiem action for searching if it requires a separate route
        [HttpGet]
        public IActionResult Tim_Kiem(int? p_iClass_ID, int? p_iTeam_ID)
        {
            return RedirectToAction("List", new { p_iClass_ID, p_iTeam_ID });
        }


        [HttpPost]
        public IActionResult Save_Data(StudentViewModel p_objRequest)
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

        private void Update_Data(StudentViewModel p_objRequest)
        {
            if (p_objRequest.StudentName.Trim() == "")
                throw new Exception("Tên sinh viên không được để trống.");

            if (p_objRequest.StudentPoB.Trim() == "")
                throw new Exception("Nơi sinh không được để trống.");

            Student v_objCheck = _context.Students.FirstOrDefault(it => it.AutoId != p_objRequest.AutoId &&
            it.StudentName.Trim() == p_objRequest.StudentName.Trim() && it.Deleted == 0);

            if (v_objCheck != null)
                throw new Exception("Tên phòng đã tồn tại.");

            p_objRequest.UpdatedBy = "tuantm";
            p_objRequest.UpdatedAt = DateTime.Now;

            Student v_objData = new Student();
            CUtility.Assign_Entity(p_objRequest, v_objData);

            _context.Students.Update(v_objData);
            _context.SaveChanges();
        }

        private void Add_Data(StudentViewModel p_objRequest)
        {
            if (p_objRequest.StudentName.Trim() == "")
                throw new Exception("Tên sinh viên không được để trống.");

            if (p_objRequest.StudentPoB.Trim() == "")
                throw new Exception("Nơi sinh không được để trống.");

            Student v_objCheck = _context.Students.FirstOrDefault(it => it.StudentName.Trim() == p_objRequest.StudentName.Trim() && it.Deleted == 0);

            if (v_objCheck != null)
                throw new Exception("Tên phòng đã tồn tại.");

            p_objRequest.UpdatedBy = "tuantm";
            p_objRequest.UpdatedAt = DateTime.Now;

            Student v_objData = new Student();
            CUtility.Assign_Entity(p_objRequest, v_objData);

            _context.Students.Add(v_objData);
            _context.SaveChanges();
        }

        #endregion
    }
}
