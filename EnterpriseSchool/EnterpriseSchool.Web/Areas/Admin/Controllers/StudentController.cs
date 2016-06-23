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
    public class StudentController : BaseController
    {
        // GET: Admin/Student
        public ActionResult AddStudent()
        {
            PopulateAlldropdown();
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(StudentViewModel viewModel)
        {
            try
            {
                StudentLevelLogic studentLevelLogic = new StudentLevelLogic();
                SessionTerm curentSessionTem = Utility.CurrentSessionTerm();
                viewModel.StudentLevel.Session = curentSessionTem.Session;
                studentLevelLogic.Create(viewModel.StudentLevel);
                SetMessage("Student added to class", Message.Category.Information);
                PopulateAlldropdown();
                return View("AddStudent");
            }
            catch (Exception)
            {
                SetMessage("Process failed", Message.Category.Error);
                PopulateAlldropdown();
                return View("AddStudent");
            }
        }

        public void PopulateAlldropdown()
        {
            try
            {
                StudentLogic studentLogic = new StudentLogic();
                StudentViewModel viewModel = new StudentViewModel();
                ViewBag.Class = viewModel.ClassSelectListItems;
                ViewBag.Level = viewModel.LevelSelectListItems;
                ViewBag.Student = new SelectList(studentLogic.GetAll(), "Id", "FullName");


            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}