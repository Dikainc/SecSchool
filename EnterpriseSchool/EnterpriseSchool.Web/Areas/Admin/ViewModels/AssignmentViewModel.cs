using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnterpriseSchool.Model.Model;
using EnterpriseSchool.Web.Models;

namespace EnterpriseSchool.Web.Areas.Admin.ViewModels
{
    public class AssignmentViewModel
    {
        public AssignmentViewModel()
        {
            ClassSelectList = Utility.PopulateClassSelectListItem();
            LevelSelectList = Utility.PopulateLevelSelectListItem();
        }
        public Assignment Assignment { get; set; }

        [Required]
        public Level Level { get; set; }

         [Required]
        public Class Class { get; set; }
        public List<SelectListItem> ClassSelectList { get; set; }
        public List<SelectListItem> LevelSelectList { get; set; }
        public HttpPostedFileBase File { get; set; }
    }
}