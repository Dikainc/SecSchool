using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSchool.Model.Model
{
    public class StudentLevel
    {
        public long Id { get; set; }
        public Level Level { get; set; }
        public Student Student { get; set; }
        public Session Session { get; set; }
        public Class Class { get; set; }
    }
}
