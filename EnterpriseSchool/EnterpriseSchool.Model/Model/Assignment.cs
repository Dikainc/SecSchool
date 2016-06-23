using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSchool.Model.Model
{
    public class Assignment
    {
        public long Id { get; set; }

        [Required]
        public string Topic { get; set; }

        [Required]
        [Display(Name = "Assignment details")]
        public string Description { get; set; }
        public Staff Staff { get; set; }

        [Display(Name="Class")]
        public ClassLevel ClassLevel { get; set; }
        public System.DateTime Date { get; set; }

        [Required]
        public DateTime? DateDue { get; set; }
        public string AttachedFileLink { get; set; }
        public bool Active { get; set; }
        public Subject Subject { get; set; }
    }
}
