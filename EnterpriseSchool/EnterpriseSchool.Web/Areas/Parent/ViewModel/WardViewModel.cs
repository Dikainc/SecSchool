using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EnterpriseSchool.Model.Model;

namespace EnterpriseSchool.Web.Areas.Parent.ViewModel
{
    public class WardViewModel
    {
        public ParentVerification ParentVerification { get; set; }
        public List<Model.Model.Student> Students { get; set; }
        public string PIN { get; set; }
    }
}