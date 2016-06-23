using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EnterpriseSchool.Model.Model;

namespace EnterpriseSchool.Web.Areas.Student.ViewModels
{
    public class StudentAssignmentViewModel
    {
        public Assignment Assignment { get; set; }
        public List<Assignment> AssignmentList { get; set; }
    }
}