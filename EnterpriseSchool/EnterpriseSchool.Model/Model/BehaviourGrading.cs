using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSchool.Model.Model
{
    public class BehaviourGrading
    {
        public long Id { get; set; }
        public Class Class { get; set; }
        public Level Level { get; set; }
        public Student Student { get; set; }
        public Term Term { get; set; }
        public Session Session { get; set; }
        public int Grade { get; set; }
        public Behaviour Behaviour { get; set; }
    }
}
