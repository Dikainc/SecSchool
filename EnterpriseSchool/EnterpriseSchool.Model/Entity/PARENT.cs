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
    
    public partial class PARENT
    {
        public PARENT()
        {
            this.PARENT_STUDENT = new HashSet<PARENT_STUDENT>();
        }
    
        public long Parent_Id { get; set; }
        public long User_Id { get; set; }
        public int Relatinship_with_Student { get; set; }
        public byte Sex_Id { get; set; }
        public string Phone_No { get; set; }
        public string Address { get; set; }
        public bool Verified { get; set; }
    
        public virtual RELATIONSHIP RELATIONSHIP { get; set; }
        public virtual SEX SEX { get; set; }
        public virtual ICollection<PARENT_STUDENT> PARENT_STUDENT { get; set; }
        public virtual USER USER { get; set; }
    }
}