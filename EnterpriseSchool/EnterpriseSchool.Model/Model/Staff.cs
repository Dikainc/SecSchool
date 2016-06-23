using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSchool.Model.Model
{
    public class Staff
    {
        public long Id  { get; set; }
        public StaffType StaffType { get; set; }
        public User User { get; set; }
        public Person Person { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherName { get; set; }
        public string FullName 
        {
            get
            {
                string FullName = FirstName + " " + LastName;
                return FullName;
            }
        }
    }
}
