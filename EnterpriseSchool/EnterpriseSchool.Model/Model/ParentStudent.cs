using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSchool.Model.Model
{
    public class ParentStudent
    {
        public long Id { get; set; }
        public Parent Parent { get; set; }
        public Student Student { get; set; }
    }
}
