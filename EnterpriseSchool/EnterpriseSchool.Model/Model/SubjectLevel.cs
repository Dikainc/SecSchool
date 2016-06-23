using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSchool.Model.Model
{
    public class SubjectLevel
    {
        public int Id { get; set; }
        public Subject Subject { get; set; }
        public Level Level { get; set; }
    }
}
