using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using EnterpriseSchool.Business;
using EnterpriseSchool.Model.Model;
using EnterpriseSchool.Web.Areas.Student.ViewModels;
using EnterpriseSchool.Web.Models;

namespace EnterpriseSchool.Web.Areas.Student.Controllers
{
    public class RegistrationController : BaseController
    {
        private RegistrationViewModel viewModel;
        [AllowAnonymous]
        public ActionResult Register()
        {
            try
            {
                SubjectLogic subjectLogic = new SubjectLogic();

                PopulateAllDropDownLists();
            }
            catch (Exception ex)
            {
                SetMessage("Error: " + ex.Message, Message.Category.Error);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegistrationViewModel viewModel)
        {
            try
            {
                PersonLogic personlogic = new PersonLogic();
                UserLogic userLogic = new UserLogic();
                StudentLogic studentLogic = new StudentLogic();
                Person person = new Person();
                Model.Model.User user = new User();
                Role role = null;
                PersonType personType = null;
                Model.Model.Student student = new Model.Model.Student();
                ParentVerification parentVerification = new ParentVerification();
                ParentVerificationLogic parentVerificationLogic = new ParentVerificationLogic();


                if (viewModel != null)
                {
                    if (Request.Files[0].ContentLength == 0)
                    {
                        SetMessage("Select passport", Message.Category.Error);
                        RetainDropDownState(viewModel);
                        return View();
                    }
                    HttpPostedFileBase hpf = Request.Files[0] as HttpPostedFileBase;
                    string pathForSaving = Server.MapPath("~/Content/img/Students");
                    string savedFileName = Path.Combine(pathForSaving, hpf.FileName);
                    string[] getExtension = hpf.FileName.Split('.');
                    string extension = "." + getExtension[1];
                    string invalidImage = InvalidFile(Request.Files[0].ContentLength, extension);
                    if (string.IsNullOrEmpty(invalidImage))
                    {
                        hpf.SaveAs(savedFileName);
                    }
                    else
                    {
                        SetMessage(invalidImage, Message.Category.Error);
                        RetainDropDownState(viewModel);
                        return View();
                    }

                    using (TransactionScope trans = new TransactionScope())
                    {
                        viewModel.Person.ImageFileUrl = "/content/img/Students/" + hpf.FileName;
                        personType = new PersonType() { Id = 1 };
                        viewModel.Person.PersonType = personType;
                        string initials = viewModel.Person.LastName + "." + viewModel.Person.FirstName.Substring(0, 1).ToUpper() + "." + viewModel.Person.OtherName.Substring(0, 1).ToUpper();
                        viewModel.Person.Initial = initials;
                        viewModel.Person.DateEntered = DateTime.Now.Date;
                        DateTime date = viewModel.Person.DateOfBirth.Value.Date;
                        viewModel.Person.DateOfBirth = (DateTime)date;

                        person = personlogic.Create(viewModel.Person);

                        var use = userLogic.GetModelBy(x => x.User_Name == User.Identity.Name);
                        use.Person = person;
                        role = new Role() { Id = 1 };
                        use.Role = role;
                        user = userLogic.UpdateUser(use);

                        // viewModel.User.LastLoginDate = DateTime.Now.Date;
                        // role = new Role() { Id = 1};
                        // viewModel.User.Role = role ;
                        // List<User> Users = userLogic.GetModelsBy(u => u.User_Name == viewModel.User.UserName);
                        // if (Users.Count != 0)
                        // {
                        //     SetMessage("User with this username already exists, choose another username", Message.Category.Error);
                        //     RetainDropDownState(viewModel);
                        //     return View();
                        // }

                        //user = userLogic.Create(viewModel.User);

                        if (viewModel.Student != null && viewModel.Student.Category.Id != 0)
                        {
                            if (viewModel.Student.Category.Id != 0)
                            {
                                viewModel.Student.Id = person.Id;
                                viewModel.Student.User = user;
                                viewModel.Student.RegNo = DateTime.Now.Year.ToString() + "/" + "LLY" + "/" + PaddRegistrationNumber(person.Id, 6);
                                student = studentLogic.Create(viewModel.Student);
                            }

                        }
                        //Add parent Verification detail
                        if (student.ParentEmail != null)
                        {
                            viewModel.ParentVerification = new ParentVerification();
                            viewModel.ParentVerification.Student = student;
                            viewModel.ParentVerification.Verified = false;
                            viewModel.ParentVerification.Detail = DateTime.Now.Year.ToString() + "/" +
                                                                  viewModel.Person.LastName.Substring(1, 4).ToUpper() + "/" +
                                                                  PaddVerificationDetail(viewModel.Person.Id, 5);
                            parentVerification = parentVerificationLogic.Create(viewModel.ParentVerification);

                        }

                        trans.Complete();
                        SetMessage("Your Registration was Successful", Message.Category.Information);

                        //Send Email to Parent
                        var send = SendEmail(student.ParentEmail, parentVerification.Detail);
                        if (send == "sent")
                        {
                            SetMessage("Parent Email Verification was successful", Message.Category.Information);
                        }
                        else
                        {
                            SetMessage("Parent Email Verification was not successful", Message.Category.Warning);

                        }
                        return RedirectToAction("Register");

                    }

                }


            }
            catch (Exception ex)
            {
                SetMessage("Error: " + ex.Message, Message.Category.Error);
            }

            return RedirectToAction("Register");


        }
        private string InvalidFile(decimal uploadedFileSize, string fileExtension)
        {
            try
            {
                string message = null;
                decimal oneKiloByte = 1024;
                decimal maximumFileSize = 1000 * oneKiloByte;

                decimal actualFileSizeToUpload = Math.Round(uploadedFileSize / oneKiloByte, 1);
                if (InvalidFileType(fileExtension))
                {
                    message = "File type '" + fileExtension + "' is invalid! File type must be any of the following: .jpg, .jpeg, .png or .jif ";
                }
                else if (actualFileSizeToUpload > (maximumFileSize / oneKiloByte))
                {
                    message = "Your file size of " + actualFileSizeToUpload.ToString("0.#") + " Kb is too large, maximum allowed size is " + (maximumFileSize / oneKiloByte) + " Kb";
                }

                return message;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private bool InvalidFileType(string extension)
        {
            extension = extension.ToLower();
            switch (extension)
            {
                case ".jpg":
                    return false;
                case ".png":
                    return false;
                case ".gif":
                    return false;
                case ".jpeg":
                    return false;
                default:
                    return true;
            }
        }
        private void PopulateAllDropDownLists()
        {
            viewModel = new RegistrationViewModel();
            ViewBag.Level = viewModel.LevelSelectList;
            ViewBag.Class = viewModel.ClassSelectList;
            ViewBag.BloodGroup = viewModel.BloodGroupSelectList;
            ViewBag.PersonType = viewModel.PersonTypeSelectList;
            ViewBag.Sex = viewModel.SexSelectList;
            ViewBag.PersonTitle = viewModel.TitleSelectList;
            ViewBag.Genotype = viewModel.GenotypeSelectList;
            ViewBag.state = new SelectList(new List<Value>(), Utility.ID, Utility.TEXT);
            ViewBag.LocalGovernment = new SelectList(new List<Value>(), Utility.ID, Utility.TEXT);
            ViewBag.Nationality = viewModel.NationalitySelectList;
            ViewBag.Country = viewModel.CountrySelectList;
            ViewBag.Religion = viewModel.ReligionSelectList;
            ViewBag.StudentCategory = viewModel.StudentCategorySelectList;
            ViewBag.StudentStatus = viewModel.StudentStatusSelectList;
        }
        private void RetainDropDownState(RegistrationViewModel viewModel)
        {
            try
            {

                ViewBag.Level = viewModel.LevelSelectList;
                ViewBag.Class = viewModel.ClassSelectList;
                ViewBag.BloodGroup = viewModel.BloodGroupSelectList;
                ViewBag.PersonType = viewModel.PersonTypeSelectList;
                ViewBag.Sex = viewModel.SexSelectList;
                ViewBag.PersonTitle = viewModel.TitleSelectList;
                ViewBag.Genotype = viewModel.GenotypeSelectList;
                ViewBag.Nationality = viewModel.NationalitySelectList;
                ViewBag.Country = viewModel.CountrySelectList;
                ViewBag.Religion = viewModel.ReligionSelectList;
                ViewBag.StudentCategory = viewModel.StudentCategorySelectList;
                ViewBag.StudentStatus = viewModel.StudentStatusSelectList;
                if (viewModel.Person.State != null)
                {
                    StateLogic stateLogic = new StateLogic();
                    ViewBag.state = new SelectList(stateLogic.GetAll(), "Id", "Name", viewModel.Person.State.Id);
                }
                else
                {
                    ViewBag.state = new SelectList(new List<Value>(), Utility.ID, Utility.TEXT);
                }

                if (viewModel.Person.State != null && viewModel.Person.LocalGovernment != null)
                {
                    LocalGovernmentLogic localGovernmentLogic = new LocalGovernmentLogic();
                    ViewBag.LocalGovernment = new SelectList(localGovernmentLogic.GetModelsBy(l => l.State_Id == viewModel.Person.State.Id), "Id", "Name", viewModel.Person.LocalGovernment.Id);
                }
                else
                {
                    ViewBag.LocalGovernment = new SelectList(new List<Value>(), Utility.ID, Utility.TEXT);
                }


            }
            catch (Exception)
            {
                throw;
            }
        }
        public JsonResult GetStates(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return null;
                }

                Nationality nationality = new Nationality() { Id = Convert.ToInt32(id) };
                StateLogic stateLogic = new StateLogic();
                List<State> states = stateLogic.GetModelsBy(s => s.Nationality_Id == nationality.Id);

                return Json(new SelectList(states, Utility.ID, Utility.NAME), JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public JsonResult GetLocalGovernments(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return null;
                }

                State state = new State() { Id = id };
                LocalGovernmentLogic localGovernmentLogic = new LocalGovernmentLogic();
                List<LocalGovernment> localGovernments = localGovernmentLogic.GetModelsBy(l => l.State_Id == state.Id);

                return Json(new SelectList(localGovernments, Utility.ID, Utility.NAME), JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private string PaddRegistrationNumber(long id, int maxCount)
        {
            try
            {
                string idInString = id.ToString();
                string paddNumbers = "";
                if (idInString.Count() < maxCount)
                {
                    int zeroCount = maxCount - id.ToString().Count();
                    StringBuilder builder = new StringBuilder();
                    for (int counter = 0; counter < zeroCount; counter++)
                    {
                        builder.Append("0");
                    }
                    builder.Append(id);
                    paddNumbers = builder.ToString();
                    return paddNumbers;
                }
                else
                {
                    paddNumbers = maxCount.ToString();
                }

                return paddNumbers;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string PaddVerificationDetail(long id, int Count)
        {
            try
            {
                string idInString = id.ToString();
                string paddNumbers = "";
                if (idInString.Count() < Count)
                {
                    int zeroCount = Count - id.ToString().Count();
                    StringBuilder builder = new StringBuilder();
                    for (int counter = 0; counter < zeroCount; counter++)
                    {
                        builder.Append("0");
                    }
                    builder.Append(id);
                    paddNumbers = builder.ToString();
                    return paddNumbers;
                }
                else
                {
                    paddNumbers = Count.ToString();
                }

                return paddNumbers;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string SendEmail(string email, string verify)
        {

            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Credentials = new NetworkCredential("engrifex@hotmail.com", "ifex1993");
                smtpClient.Host = "smtp-mail.outlook.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;

                MailMessage mailMsg = new MailMessage();

                MailAddress senderAddress = new MailAddress("engrifex@hotmail.com");
                mailMsg.Sender = senderAddress;

                mailMsg.IsBodyHtml = true; // = MailFormat.Html

                MailAddress replyTo = new MailAddress(email);
                mailMsg.ReplyToList.Add(replyTo);



                mailMsg.From = senderAddress;

                mailMsg.To.Add(email);
                mailMsg.To.Add("bizdika@gmail.com");
                mailMsg.Body = "Verification Details:" + verify + "Please enter this number in the space provided for verification in the portal";
                mailMsg.Subject = "Parent Verification For Lloydant Schools";

                smtpClient.Send(mailMsg);


                return "sent";
            }


        }

    }
}