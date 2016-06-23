using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnterpriseSchool.Web.Areas.Parent.Controllers
{
    public class AssignmentController : Controller
    {
        // GET: Parent/Assignment
        public ActionResult StudentAssignment()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult StudentAssignment()
        //{
        //    return View();
        //}
    }
}