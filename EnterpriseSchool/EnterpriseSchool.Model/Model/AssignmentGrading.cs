using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSchool.Model.Model
{
    public class AssignmentGrading
    {
        public long Id { get; set; }
        public Assignment Assignment { get; set; }
        public int Grade { get; set; }
    }
}
