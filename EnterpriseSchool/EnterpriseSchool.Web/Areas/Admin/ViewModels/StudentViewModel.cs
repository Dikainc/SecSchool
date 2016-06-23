using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnterpriseSchool.Model.Model;
using EnterpriseSchool.Web.Models;

namespace EnterpriseSchool.Web.Areas.Admin.ViewModels
{
    public class StudentViewModel
    {
        public StudentViewModel()
        {
            ClassSelectListItems = Utility.PopulateClassSelectListItem();
            LevelSelectListItems = Utility.PopulateLevelSelectListItem();
        }
        public  StudentLevel StudentLevel { get; set; }
        public List<SelectListItem> ClassSelectListItems { get; set; }
        public List<SelectListItem> LevelSelectListItems { get; set; }
    }
}