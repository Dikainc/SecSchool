using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnterpriseSchool.Model.Model;
using EnterpriseSchool.Web.Models;

namespace EnterpriseSchool.Web.Areas.Admin.ViewModels
{
    public class SetUpViewModel
    {
        public SetUpViewModel()
        {
            TermSelectList = Utility.PopulateTermSelectListItem();
            SessionSelectList = Utility.PopulateSessionSelectListItem();
        }

        public SessionTerm SessionTerm { get; set; }
        public Session Session { get; set; }
        public Term Term { get; set; }
        public List<SelectListItem> TermSelectList { get; set; }
        public List<SelectListItem> SessionSelectList { get; set; }
    }
}