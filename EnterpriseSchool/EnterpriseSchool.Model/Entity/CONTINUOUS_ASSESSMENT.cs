//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EnterpriseSchool.Model.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class CONTINUOUS_ASSESSMENT
    {
        public CONTINUOUS_ASSESSMENT()
        {
            this.RESULT = new HashSet<RESULT>();
        }
    
        public int Continuous_Assessment_Id { get; set; }
        public double CA1 { get; set; }
        public Nullable<double> CA2 { get; set; }
        public Nullable<double> CA3 { get; set; }
    
        public virtual ICollection<RESULT> RESULT { get; set; }
    }
}
