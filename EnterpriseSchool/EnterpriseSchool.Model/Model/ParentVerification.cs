using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSchool.Model.Model
{
    public class ParentVerification
    {
        public long Id { get; set; }
        public Student Student { get; set; }
        public string Detail { get; set; }
        public bool Verified { get; set; }
    }
}
