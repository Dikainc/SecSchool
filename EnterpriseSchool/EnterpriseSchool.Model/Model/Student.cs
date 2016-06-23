using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSchool.Model.Model
{
    public class Student
    {
        public long Id { get; set; }

        [Required]
        [Display(Name = "Reg. number")]
        public string RegNo { get; set; }
        public User User { get; set; }

        [Required]
        [Display(Name = "Student category")]
        public StudentCategory Category { get; set; }
        public StudentStatus Status { get; set; }

        [Display(Name = "Parents Phone no.")]
        public string ParentPhone { get; set; }

        [Display(Name = "Parent's Email")]
        public string ParentEmail { get; set; }
        public Person Person { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherName { get; set; }
    }
}
