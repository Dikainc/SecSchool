using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using EnterpriseSchool.Business;
using EnterpriseSchool.Model.Model;
using EnterpriseSchool.Web.Models;

namespace EnterpriseSchool.Web.Areas.Security.Controllers
{
    public class AccountController : BaseController
    {
        // GET: Security/Account
        
        [AllowAnonymous]
        public ActionResult Login(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(AccountViewModel.LoginViewModel viewModel, string returnUrl)
        {
            try
            {
                UserLogic userLogic = new UserLogic();
                if (userLogic.ValidateUser(viewModel.UserName, viewModel.Password))
                {
                    FormsAuthentication.SetAuthCookie(viewModel.UserName, false);
                    if (string.IsNullOrEmpty(returnUrl))
                    {
                        return RedirectToAction("Index", "Home", new { area = "" });
                    }
                    else
                    {
                        return RedirectToLocal(returnUrl);
                    }
                }
            }
            catch (Exception ex)
            {
                SetMessage("Error Occurred! " + ex.Message, Message.Category.Error);
            }

            SetMessage("Invalid Username or Password!", Message.Category.Error);
            return View();
        }

       
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account", new { Area = "Security" });
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" }); 
            }
        }

    }
}