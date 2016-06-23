using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnterpriseSchool.Business;
using EnterpriseSchool.Model.Model;
using EnterpriseSchool.Web.Areas.Admin.ViewModels;

namespace EnterpriseSchool.Web.Areas.Admin.Controllers
{
    public class SetupController : BaseController
    {
        // GET: Admin/Setup
        public ActionResult Setup()
        {
            PopulateAllDropdown();
            return View();
        }

        public ActionResult AddSession(SetUpViewModel viewModel)
        {
            try
            {
                Model.Model.Session session = new Session();
                SessionLogic sessionLogic = new SessionLogic();
                session = viewModel.Session;
                sessionLogic.Create(session);
                SetMessage("New Session Created", Message.Category.Information);
                return View("Setup");
            }
            catch (Exception e)
            {

                SetMessage("Creation failed" + e.Message, Message.Category.Information);
                return View("Setup");
            }
        }

        public ActionResult SetSessionandTerm(SetUpViewModel viewModel)
        {
            try
            {
                SessionTermLogic sessionTermLogic = new SessionTermLogic();
                SessionTerm sessionTerm = new SessionTerm();
                sessionTerm.Term = viewModel.SessionTerm.Term;
                sessionTerm.Session = viewModel.SessionTerm.Session;
                sessionTerm.Active = true;
                sessionTerm.StartDate = viewModel.SessionTerm.StartDate;
                sessionTerm.EndDate = viewModel.SessionTerm.EndDate;

                SessionTerm previousSessionsTerm = sessionTermLogic.GetModelBy(x => x.Active == true);

                if (previousSessionsTerm != null || previousSessionsTerm.Id > 0)
                {
                    previousSessionsTerm.Active = false;
                    sessionTermLogic.Update(previousSessionsTerm);
                }
                

                sessionTermLogic.Create(sessionTerm);

                SetMessage("Session and Term set", Message.Category.Information);
                PopulateAllDropdown();
                return View("Setup");
            }
            catch (Exception e)
            {

                SetMessage("Process failed " + e.Message, Message.Category.Information);
                PopulateAllDropdown();
                return View("Setup");
            }
            
        }

        private void PopulateAllDropdown()
        {
            SetUpViewModel viewModel = new SetUpViewModel();
            ViewBag.Term = viewModel.TermSelectList;
            ViewBag.Session = viewModel.SessionSelectList;
        }
    }
}