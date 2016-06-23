using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnterpriseSchool.Model.Model;
using EnterpriseSchool.Web.Models;

namespace EnterpriseSchool.Web.Areas.Student.ViewModels
{
    public class RegistrationViewModel
    {
        public RegistrationViewModel()
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
            StudentCategorySelectList = Utility.PopulateStudentCategorySelectListItem();
            StudentStatusSelectList = Utility.PopulateStudentStatusSelectListItem();
        }

        public List<SelectListItem> ClassSelectList { get; set; }

        public Person Person { get; set; }
        public User User { get; set; }
        public Model.Model.Student Student { get; set; }
        public ParentVerification ParentVerification { get; set; }

        public List<SelectListItem> StudentStatusSelectList { get; set; }

        public List<SelectListItem> StudentCategorySelectList { get; set; }

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