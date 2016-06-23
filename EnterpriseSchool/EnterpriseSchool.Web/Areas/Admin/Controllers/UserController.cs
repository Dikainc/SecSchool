using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
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
    //[Authorize(Roles = "Admin")]
    public class UserController : BaseController
    {
        public ActionResult Addstudent()
        {
            PopulateAllDropDown();
            return View();
        }

        public ActionResult Addstaff()
        {
            try
            {
                PopulateAllDropDown();
                return View();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public ActionResult Addstaffs(UserViewModel viewModel)
        {
            try
            {
                UserViewModel myViewModel = new UserViewModel();
                List<UploadStaff> uploadStaffList = new List<UploadStaff>();
                var allowedExtensions = new[] { ".xls", ".Xls" };
                HttpPostedFileBase file = viewModel.Hpf;
                var ext = Path.GetExtension(file.FileName);
                string path = "";
                if (allowedExtensions.Contains(ext))
                {
                    string fileName = "STAFF" + "_";
                    string newFileName = fileName + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "") + ext;
                    path = Path.Combine(Server.MapPath("~/StaffUpload"), newFileName);
                    file.SaveAs(path);
                }
                else
                {
                    SetMessage("Attach a valid file type and submit again, only Excel (1998 version) file is accepted", Message.Category.Error);
                    PopulateAllDropDown();
                    return View("Addstaff");
                }

                DataSet uploadedStaff = ReadExcelFile(path);
                if (uploadedStaff != null && uploadedStaff.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < uploadedStaff.Tables[0].Rows.Count; i++)
                    {
                        UploadStaff uploadStaff = new UploadStaff();
                        uploadStaff.FirstName = uploadedStaff.Tables[0].Rows[i][0].ToString();
                        uploadStaff.LastName = uploadedStaff.Tables[0].Rows[i][1].ToString();
                        uploadStaff.OtherName = uploadedStaff.Tables[0].Rows[i][2].ToString();
                        uploadStaff.Username = uploadedStaff.Tables[0].Rows[i][3].ToString();
                        uploadStaff.Password = uploadedStaff.Tables[0].Rows[i][4].ToString();
                        uploadStaff.StaffType = viewModel.Staff.StaffType;
                        uploadStaffList.Add(uploadStaff);
                    }

                }
                myViewModel.UploadStaff = uploadStaffList;
                TempData["uploadedStaff"] = myViewModel;
                Session["StaffFromExel"] = myViewModel;
                return RedirectToAction("UploadedStaff");
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult SaveStaff()
        {
            try
            {
                Role role = new Role();
                role.Id = 3;
                UserLogic userLogic = new UserLogic();
                StaffLogic staffLogic = new StaffLogic();
                UserViewModel myViewModel = (UserViewModel)Session["StaffFromExel"];
                
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        foreach (var i in myViewModel.UploadStaff)
                        {
                            User user = new User();
                            user.DateCreated = DateTime.Now;
                            user.LastLoginDate = DateTime.Now;
                            user.Role = role;
                            user.UserName = i.Username;
                            user.Password = i.Password;
                            user = userLogic.Create(user);

                            Model.Model.Staff staff = new Model.Model.Staff();
                            staff.User = user;
                            staff.StaffType = i.StaffType;
                            staff.FirstName = i.FirstName;
                            staff.LastName = i.LastName;
                            staff.OtherName = i.OtherName;
                            staffLogic.Create(staff);
                        }

                        Session.Abandon();
                        PopulateAllDropDown();
                        SetMessage("All staff has been added", Message.Category.Information);
                        transaction.Complete();
                        return View("AddStaff");
                    }

                
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public ActionResult UploadedStaff()
        {
            try
            {
                UserViewModel myModel = (UserViewModel)TempData["uploadedStaff"];
                return View(myModel);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        [HttpPost]
        public ActionResult Addstaff(UserViewModel viewModel)
        {
            try
            {
                using (TransactionScope transaction = new TransactionScope())
                {
                    StaffLogic staffLogic = new StaffLogic();
                    UserLogic userLogic = new UserLogic();
                    Role role = new Role();
                    role.Id = 3;
                    viewModel.User.DateCreated = DateTime.Now;
                    viewModel.User.LastLoginDate = DateTime.Now;
                    viewModel.User.Role = role;
                    viewModel.User = userLogic.Create(viewModel.User);

                    viewModel.Staff.User = viewModel.User;
                    staffLogic.Create(viewModel.Staff);

                    SetMessage("Staff successfully added", Message.Category.Information);
                    PopulateAllDropDown();
                    transaction.Complete();
                    return View("AddStaff");
                }
                
            }
            catch (Exception e)
            {

                SetMessage("Process Failed "+ e.Message, Message.Category.Information);
                PopulateAllDropDown();
                return View("AddStaff");
            }
        }

        [HttpPost]
        public ActionResult Addstudent(UserViewModel viewModel)
        {
            try
            {
                Role role = new Role();
                role.Id = 1;
                UserLogic userLogic = new UserLogic();
                StudentStatus studentStatus = new StudentStatus();
                studentStatus.Id = 1;
                StudentLogic studentLogic = new StudentLogic();
                StudentLevelLogic studentLevelLogic = new StudentLevelLogic();
                using (TransactionScope trans = new TransactionScope())
                {
                    viewModel.User.DateCreated = DateTime.Now;
                    viewModel.User.LastLoginDate = DateTime.Now;
                    viewModel.User.Role = role;
                    viewModel.User = userLogic.Create(viewModel.User);

                    viewModel.Student.User = viewModel.User;
                    viewModel.Student.Status = studentStatus;
                    viewModel.Student = studentLogic.Create(viewModel.Student);

                    StudentLevel studentLevel = new StudentLevel();
                    SessionTerm currentSessionTerm = Utility.CurrentSessionTerm();
                    studentLevel.Class = viewModel.Class;
                    studentLevel.Level = viewModel.Level;
                    studentLevel.Session = currentSessionTerm.Session;
                    studentLevel.Student = viewModel.Student;
                    studentLevelLogic.Create(studentLevel);

                    SetMessage("Student successfully added", Message.Category.Information);
                    PopulateAllDropDown();
                    trans.Complete();
                    return View("Addstudent");
                }

                SetMessage("Process failed", Message.Category.Error);
                PopulateAllDropDown();
                return View("Addstudent");
            }
            catch (Exception e)
            {

                SetMessage("Process failed "+ e.Message, Message.Category.Error);
                PopulateAllDropDown();
                return View("Addstudent");
            }
        }

        [HttpPost]
        public ActionResult Addstudents(UserViewModel viewModel)
        {
            try
            {
                UserViewModel myViewModel = new UserViewModel();
                List<Uploadstudent> uploadstudents = new List<Uploadstudent>();
                var allowedExtensions = new[] { ".xls", ".Xls" };
                HttpPostedFileBase file = viewModel.Hpf;
                var ext = Path.GetExtension(file.FileName);
                string path = "";
                if (allowedExtensions.Contains(ext))
                {
                    string fileName = "STUDENT" + "_";
                    string newFileName = fileName + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "") + ext;
                    path = Path.Combine(Server.MapPath("~/StudentUpload"), newFileName);
                    file.SaveAs(path);
                }
                else
                {
                    SetMessage("Attach a valid file type and submit again, only Excel (1998 version) file is accepted", Message.Category.Error);
                    PopulateAllDropDown();
                    return View("Addstudent");
                }

                DataSet uploadedStudents = ReadExcelFile(path);
                    if (uploadedStudents != null && uploadedStudents.Tables[0].Rows.Count > 0)
                    {
                        
                        
                        for (int i = 0; i < uploadedStudents.Tables[0].Rows.Count; i++)
                        {
                            Uploadstudent uploadstudent = new Uploadstudent();
                            uploadstudent.FirstName = uploadedStudents.Tables[0].Rows[i][0].ToString();
                            uploadstudent.LastName = uploadedStudents.Tables[0].Rows[i][1].ToString();
                            uploadstudent.OtherName = uploadedStudents.Tables[0].Rows[i][2].ToString();
                            uploadstudent.Username = uploadedStudents.Tables[0].Rows[i][3].ToString();
                            uploadstudent.Password = uploadedStudents.Tables[0].Rows[i][4].ToString();
                            uploadstudent.RegNo = uploadedStudents.Tables[0].Rows[i][5].ToString();
                            uploadstudent.ParentPhone = uploadedStudents.Tables[0].Rows[i][6].ToString();
                            uploadstudent.ParentEmail = uploadedStudents.Tables[0].Rows[i][7].ToString();
                            uploadstudent.Class = viewModel.Class;
                            uploadstudent.Level = viewModel.Level;
                            uploadstudent.StudentCategory = viewModel.Student.Category;
                            uploadstudents.Add(uploadstudent);
                        }

                    }
                myViewModel.Uploadstudents = uploadstudents;
                TempData["uploadstudents"] = myViewModel;
                Session["FromExel"] = myViewModel;
                return RedirectToAction("UploadedStudents");
                
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public ActionResult UploadedStudents(UserViewModel viewModel)
        {
            try
            {
                UserViewModel myModel = (UserViewModel) TempData["uploadstudents"];
                return View(myModel);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public ActionResult SaveStudents()
        {
            try
            {
                UserViewModel myViewModel = (UserViewModel) Session["FromExel"];
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        foreach (var i in myViewModel.Uploadstudents)
                        {
                            UserLogic userLogic = new UserLogic();
                            StudentLogic studentLogic = new StudentLogic();
                            Role studentRole = new Role();
                            studentRole.Id = 1;
                            StudentStatus status = new StudentStatus();
                            status.Id = 1;
                            User user = new User();
                            Model.Model.Student student = new Model.Model.Student();
                            StudentLevel studentLevel = new StudentLevel();
                            StudentLevelLogic studentLevelLogic = new StudentLevelLogic();

                            user.UserName = i.Username;
                            user.Password = i.Password;
                            user.DateCreated = DateTime.Now;
                            user.LastLoginDate = DateTime.Now;
                            user.Role = studentRole;
                            user = userLogic.Create(user);

                            student.RegNo = i.RegNo;
                            student.User = user;
                            student.Category = i.StudentCategory;
                            student.Status = status;
                            student.FirstName = i.FirstName;
                            student.LastName = i.LastName;
                            student.OtherName = i.OtherName;
                            student.ParentEmail = i.ParentEmail;
                            student.ParentPhone = i.ParentPhone;
                            student = studentLogic.Create(student);

                            SessionTerm sessionTerm = Utility.CurrentSessionTerm();
                            studentLevel.Session = sessionTerm.Session;
                            studentLevel.Class = i.Class;
                            studentLevel.Level = i.Level;
                            studentLevel.Student = student;
                            studentLevelLogic.Create(studentLevel);

                        }
                        
                        
                        Session.Abandon();
                        PopulateAllDropDown();
                        SetMessage("All student has been added", Message.Category.Information);
                        transaction.Complete();
                        return View("Addstudent");
                }

                    Session.Abandon();
                    PopulateAllDropDown();
                    SetMessage("Process failed", Message.Category.Error);
                    return View("Addstudent");
            }
            catch (Exception e)
            {
                Session.Abandon();
                PopulateAllDropDown();
                SetMessage("Process failed " + e.Message, Message.Category.Error);
                return View("Addstudent");
            }
        }

        [HttpPost]
        public ActionResult Student(UserViewModel viewModel)
        {
            try
            {
                //using ( TransactionScope transaction = new TransactionScope())
                //{
                UserLogic userLogic = new UserLogic();
                //StudentLogic studentLogic = new StudentLogic();
                //StudentStatusLogic studentStatusLogic = new StudentStatusLogic();

                User myUser = viewModel.User;
                myUser.LastLoginDate = DateTime.Now;
                myUser.UserName = viewModel.User.UserName.ToLower();
                myUser = userLogic.Create(myUser);
                    
                //viewModel.Student.User = myUser;
                //viewModel.Student.StudentStatus = studentStatusLogic.GetModelBy(x => x.Student_Status_Id == 1);

                //studentLogic.Create(viewModel.Student);
                    

                SetMessage("New user created", Message.Category.Information);
                PopulateAllDropDown();
                return View("Users");
                //}
            }
            catch (Exception e)
            {
                SetMessage("Creation failed" + e.Message, Message.Category.Error);
                PopulateAllDropDown();
                return View("Users");
            }
        }
        public void PopulateAllDropDown()
        {
            UserViewModel viewModel = new UserViewModel();
            ViewBag.Role = viewModel.RoleSelectListItem;
            ViewBag.Category = viewModel.StudentCategorySelectListItem;
            ViewBag.Class = new SelectList(new List<Class>(), "id", "Name");
            ViewBag.Level = viewModel.LevelSelectListItem;
            ViewBag.StaffType = viewModel.StaffTpeSelectListItem;
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

        public static DataSet ReadExcelFile(string filepath)
        {
            DataSet Result = null;
            try
            {
                string xConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + filepath + ";" + "Extended Properties=Excel 8.0;";
                OleDbConnection connection = new OleDbConnection(xConnStr);
                OleDbCommand command = new OleDbCommand("Select * FROM [Sheet1$]", connection);
                connection.Open();
                // Create DbDataReader to Data Worksheet

                OleDbDataAdapter MyData = new OleDbDataAdapter();
                MyData.SelectCommand = command;
                DataSet ds = new DataSet();
                ds.Clear();
                MyData.Fill(ds);
                connection.Close();

                Result = ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Result;
        }

        public FilePathResult Download(string fileName)
        {
            return new FilePathResult(string.Format(@"~\ExcelTemplates\{0}", fileName + ".xls"), "application/vnd.ms-excel");
        }
    }
}