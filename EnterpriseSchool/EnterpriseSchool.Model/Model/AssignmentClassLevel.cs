using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSchool.Model.Model
{
    public class AssignmentClassLevel
    {
        public long Id { get; set; }
        public Assignment Assignment { get; set; }
        public ClassLevel ClassLevel { get; set; }
    }
}
