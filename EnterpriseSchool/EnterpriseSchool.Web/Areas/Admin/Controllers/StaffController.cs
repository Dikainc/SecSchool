using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnterpriseSchool.Business;
using EnterpriseSchool.Model.Model;
using EnterpriseSchool.Web.Areas.Admin.ViewModels;
using EnterpriseSchool.Web.Models;

namespace EnterpriseSchool.Web.Areas.Admin.Controllers
{
    public class StaffController : BaseController
    {
        // GET: Admin/Staff
        public ActionResult AssignStaff()
        {
            PopulateAllDropdown();
            return View();
        }

        [HttpPost]
        public ActionResult AssignStaff(StaffViewModel viewModel)
        {
            try
            {
               TeacherSubjectAllocationLogic teacherSubjectAllocationLogic = new TeacherSubjectAllocationLogic();

                SessionTerm currentSessionTerm = Utility.CurrentSessionTerm();

                viewModel.TeacherSubjectAllocation.Activated = true;
                viewModel.TeacherSubjectAllocation.Session = currentSessionTerm.Session;

                teacherSubjectAllocationLogic.Create(viewModel.TeacherSubjectAllocation);

                SetMessage("Staff successfully allocated to subject", Message.Category.Information);
                PopulateAllDropdown();
                return View("AssignStaff");
            }
            catch (Exception)
            {
                SetMessage("Process Failed", Message.Category.Error);
                PopulateAllDropdown();
                return View("AssignStaff");
            }
        }

        private void PopulateAllDropdown()
        {
            StaffLogic staffLogic = new StaffLogic();
            StaffViewModel viewModel = new StaffViewModel();
            ViewBag.Level = viewModel.LevelSelectList;
            ViewBag.Class = viewModel.ClassSelectList;
            ViewBag.Subject = viewModel.SubjectSelectList;
            ViewBag.Staff = new SelectList(staffLogic.GetModelsBy(x => x.Staff_Type_Id == 1), "Id", "FullName");
        }
    }
}