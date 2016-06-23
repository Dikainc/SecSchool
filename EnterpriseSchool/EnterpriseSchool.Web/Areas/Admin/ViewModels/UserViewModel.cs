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
    public class UserViewModel
    {
        public UserViewModel()
        {
            RoleSelectListItem = Utility.PopulateRoleSelectListItem();
            StudentCategorySelectListItem = Utility.PopulateStudentCategorySelectListItem();
            ClassSelectListItem = Utility.PopulateClassSelectListItem();
            LevelSelectListItem = Utility.PopulateLevelSelectListItem();
            StaffTpeSelectListItem = Utility.PopulateStaffTypeSelectListItem();
        }
        public User User { get; set; }
        public User EditUser { get; set; }
        public Model.Model.Staff Staff { get; set; }
        public List<SelectListItem> RoleSelectListItem { get; set; }
        public List<SelectListItem> StudentCategorySelectListItem { get; set; }
        public List<SelectListItem> ClassSelectListItem { get; set; }
        public List<SelectListItem> LevelSelectListItem { get; set; }
        public List<SelectListItem> StaffTpeSelectListItem { get; set; }
        public Model.Model.Student Student { get; set; }
        public Class Class { get; set; }
        public Level Level { get; set; }

        [Required]
        [Display(Name = "Upload Excel file")]
        public HttpPostedFileBase Hpf { get; set; }
        public List<Uploadstudent> Uploadstudents { get; set; }
        public List<UploadStaff> UploadStaff { get; set; }
    }

    public class Uploadstudent
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string  RegNo { get; set; }
        public string ParentPhone { get; set; }
        public string ParentEmail { get; set; }
        public Level Level { get; set; }
        public Class Class { get; set; }
        public StudentCategory StudentCategory { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherName { get; set; }
    }

    public class UploadStaff
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public StaffType StaffType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherName { get; set; }
    }
}