using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSchool.Model.Model
{
    public class FeeDetail
    {
        public int Id { get; set; }
        public Fee Fee { get; set; }
        public FeeType FeeType { get; set; }
        public Level Level { get; set; }
        public Session Session { get; set; }
    }
}
