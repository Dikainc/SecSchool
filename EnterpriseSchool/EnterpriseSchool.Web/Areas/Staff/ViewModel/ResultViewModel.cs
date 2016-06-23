using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnterpriseSchool.Model.Model;
using EnterpriseSchool.Web.Models;

namespace EnterpriseSchool.Web.Areas.Staff.ViewModel
{
    public class ResultViewModel
    {
        public ResultViewModel()
        {
            ClassSelectList = Utility.PopulateClassSelectListItem();
            LevelSelectList = Utility.PopulateLevelSelectListItem();

        }

        public Behaviour Behaviour { get; set; }
        public Skill Skill { get; set; }
        public ContinuousAssessment ContinuousAssessment { get; set; }

        public List<SelectListItem> LevelSelectList { get; set; }

        public List<SelectListItem> ClassSelectList { get; set; }
    }
}