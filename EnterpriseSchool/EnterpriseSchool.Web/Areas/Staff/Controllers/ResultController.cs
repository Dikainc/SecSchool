using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnterpriseSchool.Model.Model;
using EnterpriseSchool.Web.Areas.Admin.Controllers;
using EnterpriseSchool.Web.Areas.Staff.ViewModel;
/*
namespace EnterpriseSchool.Web.Areas.Staff.Controllers
{
    public class ResultController : BaseController
    {
        private const string ID = "Id";
        private const string NAME = "Name";
        private ResultViewModel viewModel;

        public ResultController()
        {
            
        }




        public ActionResult DownloadResultSheet()
        {
            try
            {
                ResultViewModel viewModel = new ResultViewModel();
                ViewBag.AllSession = viewModel.AllSessionSelectList;
                ViewBag.Semester = new SelectList(new List<Semester>(), ID, NAME);
                ViewBag.Programme = viewModel.ProgrammeSelectList;
                ViewBag.Department = new SelectList(new List<Department>(), ID, NAME);
                ViewBag.Level = new SelectList(viewModel.LevelList, ID, NAME);
                ViewBag.Course = new SelectList(new List<Course>(), ID, NAME);

            }
            catch (Exception ex)
            {
                SetMessage("Error Occured!" + ex.Message, Message.Category.Error);

            }
            return View();
        }
        [HttpPost]
        public ActionResult DownloadResultSheet(ResultViewModel viewModel)
        {
            try
            {
                GridView gv = new GridView();
                DataTable ds = new DataTable();
                List<ResultFormat> resultFormatList = new List<ResultFormat>();

                SessionLogic sessionLogic = new SessionLogic();
                //Session session = sessionLogic.GetModelBy(p => p.Session_Id == viewModel.Session.Id);
                CourseRegistrationDetailLogic courseRegistrationDetailLogic = new CourseRegistrationDetailLogic();
                List<CourseRegistrationDetail> courseRegistrationDetailList = new List<CourseRegistrationDetail>();
                List<CourseRegistration> courseRegistrationList = new List<CourseRegistration>();
                CourseRegistrationLogic courseRegistrationLogic = new CourseRegistrationLogic();
                courseRegistrationList = courseRegistrationLogic.GetModelsBy(p => p.Session_Id == viewModel.Session.Id && p.Level_Id == viewModel.Level.Id && p.Department_Id == viewModel.Department.Id && p.Programme_Id == viewModel.Programme.Id);
                if (viewModel.Course != null && viewModel.Semester != null && courseRegistrationList.Count > 0)
                {
                    int count = 1;
                    foreach (CourseRegistration courseRegistration in courseRegistrationList)
                    {
                        courseRegistrationDetailList = courseRegistrationDetailLogic.GetModelsBy(p => p.Course_Id == viewModel.Course.Id && p.Semester_Id == viewModel.Semester.Id && p.Student_Course_Registration_Id == courseRegistration.Id);
                        if (courseRegistrationDetailList.Count > 0)
                        {

                            foreach (CourseRegistrationDetail courseRegistrationDetailItem in courseRegistrationDetailList)
                            {
                                ResultFormat resultFormat = new ResultFormat();
                                //resultFormat.SN = count;
                                resultFormat.MATRICNO = courseRegistrationDetailItem.CourseRegistration.Student.MatricNumber.Trim();
                                resultFormatList.Add(resultFormat);

                                count++;
                            }

                        }
                    }

                }

                if (resultFormatList.Count > 0)
                {
                    List<ResultFormat> list = resultFormatList.OrderBy(p => p.MATRICNO).ToList();
                    List<ResultFormat> sort = new List<ResultFormat>();
                    for (int i = 0; i < list.Count; i++)
                    {
                        list[i].SN = (i + 1);
                        sort.Add(list[i]);
                    }

                    gv.DataSource = sort;// resultFormatList.OrderBy(p => p.MATRICNO);
                    CourseLogic courseLogic = new CourseLogic();
                    Course course = courseLogic.GetModelBy(p => p.Course_Id == viewModel.Course.Id);
                    gv.Caption = course.Code + " " + " DEPARTMENT OF " + " " + course.Department.Name.ToUpper() + " " + course.Unit + " " + "Units";
                    gv.DataBind();


                    return new DownloadFileActionResult(gv, "ResultSheet.xls");
                }
                else
                {
                    Response.Write("No data available for download");
                    Response.End();
                    return new JavaScriptResult();
                }

            }
            catch (Exception ex)
            {

                SetMessage("Error occured! " + ex.Message, Message.Category.Error);
            }
            return RedirectToAction("DownloadResultSheet");
        }

        public ActionResult UploadResultSheet()
        {
            try
            {
                ResultViewModel viewModel = new ResultViewModel();
                ViewBag.AllSession = viewModel.AllSessionSelectList;
                ViewBag.Semester = new SelectList(new List<Semester>(), ID, NAME);
                ViewBag.Programme = viewModel.ProgrammeSelectList;
                ViewBag.Department = new SelectList(new List<Department>(), ID, NAME);
                ViewBag.Level = new SelectList(viewModel.LevelList, ID, NAME);
                ViewBag.Course = new SelectList(new List<Course>(), ID, NAME);

            }
            catch (Exception ex)
            {
                SetMessage("Error Occured!" + ex.Message, Message.Category.Error);

            }
            return View();
        }
        [HttpPost]
        public ActionResult UploadResultSheet(ResultViewModel viewModel)
        {
            try
            {
                List<ResultFormat> resultFormatList = new List<ResultFormat>();
                foreach (string file in Request.Files)
                {
                    HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                    string pathForSaving = Server.MapPath("~/Content/ExcelUploads");
                    string savedFileName = Path.Combine(pathForSaving, hpf.FileName);
                    hpf.SaveAs(savedFileName);
                    DataSet studentSet = ReadExcel(savedFileName);

                    if (studentSet != null && studentSet.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 1; i < studentSet.Tables[0].Rows.Count; i++)
                        {
                            ResultFormat resultFormat = new ResultFormat();
                            resultFormat.SN = Convert.ToInt32(studentSet.Tables[0].Rows[i][0].ToString().Trim());
                            resultFormat.MATRICNO = studentSet.Tables[0].Rows[i][1].ToString().Trim();
                            resultFormat.QU1 = Convert.ToDecimal(studentSet.Tables[0].Rows[i][2].ToString().Trim());
                            resultFormat.QU2 = Convert.ToDecimal(studentSet.Tables[0].Rows[i][3].ToString().Trim());
                            resultFormat.QU3 = Convert.ToDecimal(studentSet.Tables[0].Rows[i][4].ToString().Trim());
                            resultFormat.QU4 = Convert.ToDecimal(studentSet.Tables[0].Rows[i][5].ToString().Trim());
                            resultFormat.QU5 = Convert.ToDecimal(studentSet.Tables[0].Rows[i][6].ToString().Trim());
                            resultFormat.QU6 = Convert.ToDecimal(studentSet.Tables[0].Rows[i][7].ToString().Trim());
                            resultFormat.QU7 = Convert.ToDecimal(studentSet.Tables[0].Rows[i][8].ToString().Trim());
                            resultFormat.QU8 = Convert.ToDecimal(studentSet.Tables[0].Rows[i][9].ToString().Trim());
                            resultFormat.QU9 = Convert.ToDecimal(studentSet.Tables[0].Rows[i][10].ToString().Trim());
                            resultFormat.T_EX = Convert.ToDecimal(studentSet.Tables[0].Rows[i][11].ToString().Trim());
                            resultFormat.T_CA = Convert.ToDecimal(studentSet.Tables[0].Rows[i][12].ToString().Trim());
                            resultFormat.EX_CA = Convert.ToDecimal(studentSet.Tables[0].Rows[i][13].ToString().Trim());

                            if (resultFormat.MATRICNO != "")
                            {
                                resultFormatList.Add(resultFormat);
                            }

                        }
                        resultFormatList.OrderBy(p => p.MATRICNO);
                        viewModel.resultFormatList = resultFormatList;
                        TempData["resultUploadViewModel"] = viewModel;

                    }

                }
            }
            catch (Exception ex)
            {

                SetMessage("Error occured! " + ex.Message, Message.Category.Error);
            }
            RetainDropdownState(viewModel);
            return View(viewModel);
        }
        public ActionResult SaveUploadedResultSheet()
        {
            ResultViewModel viewModel = (ResultViewModel)TempData["resultUploadViewModel"];
            try
            {
                if (viewModel != null)
                {

                    int status = validateFields(viewModel.resultFormatList);

                    if (status > 0)
                    {
                        ResultFormat format = viewModel.resultFormatList.ElementAt((status - 1));
                        SetMessage("Validation Error for" + " " + format.MATRICNO, Message.Category.Error);
                        RetainDropdownState(viewModel);
                        return RedirectToAction("UploadResultSheet");
                    }

                    bool resultAdditionStatus = addStudentResult(viewModel);

                    SetMessage("Upload successful", Message.Category.Information);
                }


            }
            catch (Exception ex)
            {

                SetMessage("Error occured " + ex.Message, Message.Category.Error);
            }

            RetainDropdownState(viewModel);
            return View("UploadResultSheet");
        }
        public ActionResult ProcessResult()
        {
            try
            {
                ResultViewModel viewModel = new ResultViewModel();
                ViewBag.AllSession = viewModel.AllSessionSelectList;
                ViewBag.Semester = new SelectList(new List<Semester>(), ID, NAME);
                // ViewBag.StudentType = viewModel.StudentTypeSelectList;
                ViewBag.Programme = viewModel.ProgrammeSelectList;
                ViewBag.Department = new SelectList(new List<Department>(), ID, NAME);
                ViewBag.Level = new SelectList(viewModel.LevelList, ID, NAME);
            }
            catch (Exception)
            {
                throw;
            }
            return View();
        }
        [HttpPost]
        public ActionResult ProcessResult(ResultViewModel viewModel)
        {
            try
            {
                if (viewModel != null)
                {
                    if (viewModel.Semester != null && viewModel.Session != null && viewModel.Programme != null && viewModel.Department != null && viewModel.Level != null)
                    {
                        GetResultList(viewModel);
                        TempData["ResultUploadViewModel"] = viewModel;
                        RetainDropdownState(viewModel);
                    }

                }
            }
            catch (Exception ex)
            {

                SetMessage("Error Occured!" + ex.Message, Message.Category.Error);
            }
            return View(viewModel);
        }

        private DataSet ReadExcel(string filepath)
        {
            DataSet Result = null;
            try
            {
                string xConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + filepath + ";" + "Extended Properties=Excel 8.0;";
                OleDbConnection connection = new OleDbConnection(xConnStr);

                connection.Open();
                DataTable sheet = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                foreach (DataRow dataRow in sheet.Rows)
                {
                    string sheetName = dataRow[2].ToString().Replace("'", "");
                    OleDbCommand command = new OleDbCommand("Select * FROM [" + sheetName + "]", connection);
                    // Create DbDataReader to Data Worksheet

                    OleDbDataAdapter MyData = new OleDbDataAdapter();
                    MyData.SelectCommand = command;
                    DataSet ds = new DataSet();
                    ds.Clear();
                    MyData.Fill(ds);
                    connection.Close();

                    Result = ds;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Result;

        }

    }
}*/