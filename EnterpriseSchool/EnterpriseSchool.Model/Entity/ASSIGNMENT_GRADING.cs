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
    
    public partial class ASSIGNMENT_GRADING
    {
        public long Assignment_Grading_Id { get; set; }
        public long Assignment_Id { get; set; }
        public int Assignment_Grade { get; set; }
    
        public virtual ASSIGNMENT ASSIGNMENT { get; set; }
    }
}
