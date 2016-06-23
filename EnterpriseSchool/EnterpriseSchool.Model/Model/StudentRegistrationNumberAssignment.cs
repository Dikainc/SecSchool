using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSchool.Model.Model
{
    class StudentRegistrationNumberAssignment
    {
        public Class Class { get; set; }
        public Level Level { get; set; }
        public Session Session { get; set; }
        public int RegSerialNumberStartFrom { get; set; }
        public string RegNumberStartFrom { get; set; }
        public bool Used { get; set; }
    
    }
}
