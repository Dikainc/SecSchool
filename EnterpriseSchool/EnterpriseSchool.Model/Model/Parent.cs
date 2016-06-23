using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSchool.Model.Model
{
    public class Parent 
    {
        public long Id { get; set; }
        public User User { get; set; }
        public Relationship RelatinshipWithStudent { get; set; }
        public Sex Sex { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public bool Verified { get; set; }
    }
}
