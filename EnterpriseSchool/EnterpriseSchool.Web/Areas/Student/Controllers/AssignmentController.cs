using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnterpriseSchool.Business;
using EnterpriseSchool.Model.Model;
using EnterpriseSchool.Web.Areas.Student.ViewModels;
using EnterpriseSchool.Web.Models;

namespace EnterpriseSchool.Web.Areas.Student.Controllers
{
    public class AssignmentController : Controller
    {
        // GET: Student/Assignment
        public ActionResult Assignment()
        {
            try
            {
                StudentAssignmentViewModel viewModel = new StudentAssignmentViewModel();
                AssignmentLogic assignmentLogic = new AssignmentLogic();
                ClassLevelLogic classLevelLogic = new ClassLevelLogic();
                AssignmentClassLevelLogic assignmentClassLevelLogic = new AssignmentClassLevelLogic();
                UserLogic userLogic = new UserLogic();
                StudentLogic studentLogic = new StudentLogic();
                Model.Model.User loggedinStudentUser =
                    userLogic.GetModelBy(x => x.User_Name == User.Identity.Name.ToLower());
                Model.Model.Student student = studentLogic.GetModelBy(x => x.User_Id == loggedinStudentUser.Id);
                StudentLevel StudentClassAndLevel = Utility.StudentsClassLevel(student);
                ClassLevel classLevel =
                    classLevelLogic.GetModelBy(
                        x => x.Class_Id == StudentClassAndLevel.Class.Id && x.Level_Id == StudentClassAndLevel.Level.Id);
                var allassignments = assignmentClassLevelLogic.GetAll().Where(x => x.ClassLevel == classLevel);

                List<Assignment> allAssignments = new List<Assignment>();
                foreach (var i in allassignments)
                {
                    Assignment AllAssignment = assignmentLogic.GetModelBy(x => x.Assignment_Id == i.Assignment.Id);
                    allAssignments.Add(AllAssignment);
                }

                viewModel.AssignmentList = allAssignments;
                return View(viewModel.AssignmentList);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}