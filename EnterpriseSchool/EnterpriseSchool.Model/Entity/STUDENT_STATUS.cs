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
    
    public partial class STUDENT_STATUS
    {
        public STUDENT_STATUS()
        {
            this.STUDENT = new HashSet<STUDENT>();
        }
    
        public int Student_Status_Id { get; set; }
        public string Student_Status_Name { get; set; }
        public string Student_Status_Description { get; set; }
    
        public virtual ICollection<STUDENT> STUDENT { get; set; }
    }
}
