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
    
    public partial class SUBJECT_LEVEL
    {
        public int Subject_Level_Id { get; set; }
        public int Subject_Id { get; set; }
        public int Level_Id { get; set; }
    
        public virtual LEVEL LEVEL { get; set; }
        public virtual SUBJECT SUBJECT { get; set; }
    }
}