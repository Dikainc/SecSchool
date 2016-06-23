using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnterpriseSchool.Model.Model;
using EnterpriseSchool.Web.Models;

namespace EnterpriseSchool.Web.Areas.Admin.ViewModels
{
    public class StaffViewModel
    {
        public StaffViewModel()
        {
            SubjectSelectList = Utility.PopulateSubjectSelectListItem();
            LevelSelectList = Utility.PopulateLevelSelectListItem();
            ClassSelectList = Utility.PopulateClassSelectListItem();
        }
        public TeacherSubjectAllocation TeacherSubjectAllocation { get; set; }
        public List<SelectListItem> ClassSelectList { get; set; }
        public List<SelectListItem> SubjectSelectList { get; set; }
        public List<SelectListItem> LevelSelectList { get; set; }
    }
}