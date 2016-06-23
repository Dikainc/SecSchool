using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSchool.Model.Model
{
    public class ClassLevel
    {
        public int Id { get; set; }
        public Level Level { get; set; }
        public Class Class { get; set; }
    }
}
