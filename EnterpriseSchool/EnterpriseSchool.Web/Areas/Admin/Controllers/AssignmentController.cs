using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using EnterpriseSchool.Business;
using EnterpriseSchool.Model.Model;
using EnterpriseSchool.Web.Areas.Admin.ViewModels;
using EnterpriseSchool.Web.Models;

namespace EnterpriseSchool.Web.Areas.Admin.Controllers
{
    public class AssignmentController : BaseController
    {
        // GET: Admin/Assignment
        public ActionResult SetAssignment()
        {
            PupulateAllDropdown();
            return View();
        }

        [HttpPost]
        public ActionResult SetAssignment(AssignmentViewModel viewModel)
        {
            try
            {
                AssignmentClassLevelLogic assignmentClassLevelLogic = new AssignmentClassLevelLogic();
                UserLogic userLogic = new UserLogic();
                StaffLogic staffLogic = new StaffLogic();
                ClassLevelLogic classLevelLogic = new ClassLevelLogic();
                AssignmentLogic assignmentLogic = new AssignmentLogic();
                Assignment assignment = new Assignment();
                if (viewModel.File == null)
                {
                    assignment = viewModel.Assignment;
                    assignment.Active = true;
                    assignment.ClassLevel =
                        classLevelLogic.GetModelBy(
                            x => x.Class_Id == viewModel.Class.Id && x.Level_Id == viewModel.Level.Id);
                    assignment.Date = DateTime.Now;
                    User myUser = userLogic.GetModelBy(p => p.User_Name == User.Identity.Name);
                    assignment.Staff =
                        staffLogic.GetModelBy(
                            x => x.User_Id == myUser.Id);
                    assignment = assignmentLogic.Create(assignment);

                    AssignmentClassLevel assignmentClassLevel = new AssignmentClassLevel();
                    assignmentClassLevel.Assignment = assignment;
                    assignmentClassLevel.ClassLevel = classLevelLogic.GetModelBy(
                            x => x.Class_Id == viewModel.Class.Id && x.Level_Id == viewModel.Level.Id);
                    assignmentClassLevelLogic.Create(assignmentClassLevel);

                    SetMessage("Assignment sent", Message.Category.Information);
                    PupulateAllDropdown();
                    return View("SetAssignment");
                }

                else
                {
                    var allowedExtensions = new[] { ".Jpg", ".png", ".jpg", ".jpeg", ".gif", ".Gif", ".doc", ".docx", ".Doc", ".Docx", ".pdf", ".Pdf" };
                    HttpPostedFileBase file = viewModel.File;
                    var ext = Path.GetExtension(file.FileName);

                    if (allowedExtensions.Contains(ext))
                    {
                        using (var trans = new TransactionScope())
                        {
                            SubjectLogic subjectLogic = new SubjectLogic();
                            assignment = viewModel.Assignment;
                            assignment.Active = true;
                            assignment.ClassLevel =
                                classLevelLogic.GetModelBy(
                                    x => x.Class_Id == viewModel.Class.Id && x.Level_Id == viewModel.Level.Id);
                            assignment.Date = DateTime.Now;
                            User myUser = userLogic.GetModelBy(p => p.User_Name == User.Identity.Name);
                            assignment.Staff =
                                staffLogic.GetModelBy(
                                    x => x.User_Id == myUser.Id);
                            Subject subject = subjectLogic.GetModelBy(x => x.Subject_Id == assignment.Subject.Id);

                            string newName = subject.Name.Substring(0, 3).ToUpper() + assignment.Staff.Id.ToString("D4").ToUpper() + ext; //Renamning the file
                            var path = Path.Combine(Server.MapPath("~/Assignment"), newName);
                            file.SaveAs(path);
                            assignment.AttachedFileLink = "/Assignment/" + newName;

                            assignmentLogic.Create(assignment);
                            SetMessage("Assignment sent", Message.Category.Information);
                            PupulateAllDropdown();
                            trans.Complete();
                            return View("SetAssignment");
                        }
                    }
                    else
                    {
                        SetMessage("Attach a valid file type and submit again", Message.Category.Error);
                        PupulateAllDropdown();
                        return View("SetAssignment");
                    }
                }
                
            }
            catch (Exception e)
            {

                SetMessage("Assignment submission failed :" + e.Message, Message.Category.Error);
                PupulateAllDropdown();
                return View("SetAssignment");
            }
        }
        public JsonResult LevelChangeForClassDropDown(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return null;
                }

                ClassLevelLogic classLevelLogic = new ClassLevelLogic();

                int Id = Convert.ToInt32(id);

                List<ClassLevel> ClassesInLevel = classLevelLogic.GetModelsBy(x => x.Level_Id == Id);
                
                ClassLogic classLogic = new ClassLogic();

                List<Class> allClasses = new List<Class>();

                foreach (var i in ClassesInLevel)
                {
                    allClasses.Add(i.Class);
                }
                
                List<SelectListItem> itemsSelectList = new List<SelectListItem>();

                //if (allClasses.Count() != 0)
                //{
                    foreach (var i in allClasses)
                    {
                        SelectListItem selectList = new SelectListItem();
                        selectList.Value = i.Id.ToString();
                        selectList.Text = i.Name;
                        itemsSelectList.Add(selectList);
                    }
                //}
                

                return Json(itemsSelectList, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public JsonResult LevelChangeForSubjectDropDown(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return null;
                }

                SubjectLevelLogic subjectLevelLogic = new SubjectLevelLogic();

                int Id = Convert.ToInt32(id);

                var SubjectsOfferdByLevel = subjectLevelLogic.GetAll().Where(x => x.Level.Id == Id);

                SubjectLogic subjectLogic = new SubjectLogic();

                List<Subject> allSubjects = new List<Subject>();

                foreach (var i in SubjectsOfferdByLevel)
                {
                    allSubjects.Add(i.Subject);
                }

                List<SelectListItem> itemsSelectList = new List<SelectListItem>();

                foreach (var i in allSubjects)
                {
                    SelectListItem selectList = new SelectListItem();
                    selectList.Value = i.Id.ToString();
                    selectList.Text = i.Name;
                    itemsSelectList.Add(selectList);
                }

                return Json(itemsSelectList, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void PupulateAllDropdown()
        {
            try
            {
                AssignmentViewModel viewModel = new AssignmentViewModel();
                ViewBag.Class = new SelectList(new List<Class>(), "Id", "Name");
                ViewBag.Subject = new SelectList(new List<Subject>(), "Id", "Name");
                ViewBag.Level = viewModel.LevelSelectList;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}