using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSchool.Model.Model
{
    public class TeacherClassAllocation
    {
        public int Id { get; set; }
        public Staff Staff { get; set; }
        public Level Level { get; set; }
        public Class Class { get; set; }
        public Session Session { get; set; }
        public bool Activated { get; set; }
        public string DeactivationReason { get; set; }
    }
}
