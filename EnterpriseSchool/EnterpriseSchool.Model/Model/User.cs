using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSchool.Model.Model
{
    public class User
    {
        public long Id { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
        public Role Role { get; set; }
        public Person Person { get; set; }
        public System.DateTime? LastLoginDate { get; set; }
        public System.DateTime DateCreated { get; set; }
    }
}
