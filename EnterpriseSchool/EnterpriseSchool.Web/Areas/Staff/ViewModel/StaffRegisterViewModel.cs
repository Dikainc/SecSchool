using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnterpriseSchool.Model.Model;
using EnterpriseSchool.Web.Models;

namespace EnterpriseSchool.Web.Areas.Staff.ViewModel
{
    public class StaffRegisterViewModel
    {
        public StaffRegisterViewModel()
        {
            
      
        ClassSelectList = Utility.PopulateClassSelectListItem();
            PersonTypeSelectList = Utility.PopulatePersonTypeSelectListItem();
            LevelSelectList = Utility.PopulateLevelSelectListItem();
            TitleSelectList = Utility.PopulateTitleSelectListItem();
            GenotypeSelectList = Utility.PopulateGenotypeSelectListItem();
            StateSelectList = Utility.PopulateStateSelectListItem();
            CountrySelectList = Utility.PopulateCountrySelectListItem();
            NationalitySelectList = Utility.PopulateNationalitySelectListItem();
            ReligionSelectList = Utility.PopulateReligionSelectListItem();
            SexSelectList = Utility.PopulateSexSelectListItem();
            BloodGroupSelectList = Utility.PopulateBloodGroupSelectListItem();
            StaffTypeSelectList = Utility.PopulateStaffTypeSelectListItem();
              }
  

    
        public List<SelectListItem> ClassSelectList { get; set; }

        public Person Person { get; set; }
        public User User { get; set; }
        public Model.Model.Staff Staff { get; set; }
       
        public List<SelectListItem> StaffTypeSelectList { get; set; }

        public List<SelectListItem> PersonTypeSelectList { get; set; }
        public List<SelectListItem> LevelSelectList { get; set; }
        public List<SelectListItem> SexSelectList { get; set; }
        public List<SelectListItem> TitleSelectList { get; set; }
        public List<SelectListItem> GenotypeSelectList { get; set; }
        public List<SelectListItem> StateSelectList { get; set; }
        public List<SelectListItem> CountrySelectList { get; set; }
        public List<SelectListItem> NationalitySelectList { get; set; }
        public List<SelectListItem> ReligionSelectList { get; set; }
        public List<SelectListItem> BloodGroupSelectList { get; set; }
}
}