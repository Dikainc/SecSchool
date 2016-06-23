using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnterpriseSchool.Business;
using EnterpriseSchool.Model.Model;
using EnterpriseSchool.Web.Areas.Parent.ViewModel;

namespace EnterpriseSchool.Web.Areas.Parent.Controllers
{
    public class WardController : BaseController
    {
        // GET: Parent/AssWard
        public ActionResult VerifyWard()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VerifyWard(WardViewModel viewModel)
        {
            try
            {
                ParentLogic parentLogic = new ParentLogic();
                UserLogic userLogic = new UserLogic();
                ParentStudentLogic parentStudentLogic = new ParentStudentLogic();
                ParentVerificationLogic parentVerificationLogic = new ParentVerificationLogic();
                var modelwithPIN =
                    parentVerificationLogic.GetAll().Where(
                        x => x.Detail == viewModel.ParentVerification.Detail.ToUpper());
                if (modelwithPIN.Count() == 0)
                {
                    SetMessage("Enter a valid PIN", Message.Category.Error);
                    return View("VerifyWard");
                }
                
                //FInding the parent who is signed in
                User SignedInUser = userLogic.GetModelBy(x => x.User_Name == User.Identity.Name.ToLower());
                Model.Model.Parent parent = parentLogic.GetModelBy(x => x.User_Id == SignedInUser.Id);
                if (parent == null)
                {
                    SetMessage("You are not registered as a parent, you need to be a parent to perform this action", Message.Category.Error);
                    return View("VerifyWard");
                }

                foreach(var i in modelwithPIN)
                {
                    if (i.Verified == false)
                    {
                        ParentStudent parentStudent = new ParentStudent();
                        parentStudent.Parent = parent;
                        parentStudent.Student = i.Student;
                        parentStudentLogic.Create(parentStudent);
                        parentVerificationLogic.Update(i);
                    }
                    else
                    {
                        SetMessage("You have already added this student as you ward", Message.Category.Warning);
                        return View("VerifyWard");
                    }
                    
                }

                SetMessage("Student has been added as you ward", Message.Category.Information);
                return View("VerifyWard");
            }
            catch (Exception e)
            {

                SetMessage("Process Failed "+  e.Message, Message.Category.Error);
                return View("VerifyWard");
            }
        }
    }
}