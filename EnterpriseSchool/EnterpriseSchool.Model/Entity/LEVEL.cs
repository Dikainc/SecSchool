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
    
    public partial class LEVEL
    {
        public LEVEL()
        {
            this.BEHAVIOUR_GRADING = new HashSet<BEHAVIOUR_GRADING>();
            this.CLASS_LEVEL = new HashSet<CLASS_LEVEL>();
            this.FEE_DETAIL = new HashSet<FEE_DETAIL>();
            this.RESULT = new HashSet<RESULT>();
            this.STUDENT_LEVEL = new HashSet<STUDENT_LEVEL>();
            this.STUDENT_REGISTRATION_NUMBER_ASSIGNMENT = new HashSet<STUDENT_REGISTRATION_NUMBER_ASSIGNMENT>();
            this.SUBJECT_LEVEL = new HashSet<SUBJECT_LEVEL>();
            this.TEACHER_SUBJECT_ALLOCATION = new HashSet<TEACHER_SUBJECT_ALLOCATION>();
        }
    
        public int Level_Id { get; set; }
        public string Level_Name { get; set; }
        public bool Activated { get; set; }
    
        public virtual ICollection<BEHAVIOUR_GRADING> BEHAVIOUR_GRADING { get; set; }
        public virtual ICollection<CLASS_LEVEL> CLASS_LEVEL { get; set; }
        public virtual ICollection<FEE_DETAIL> FEE_DETAIL { get; set; }
        public virtual ICollection<RESULT> RESULT { get; set; }
        public virtual ICollection<STUDENT_LEVEL> STUDENT_LEVEL { get; set; }
        public virtual ICollection<STUDENT_REGISTRATION_NUMBER_ASSIGNMENT> STUDENT_REGISTRATION_NUMBER_ASSIGNMENT { get; set; }
        public virtual ICollection<SUBJECT_LEVEL> SUBJECT_LEVEL { get; set; }
        public virtual ICollection<TEACHER_SUBJECT_ALLOCATION> TEACHER_SUBJECT_ALLOCATION { get; set; }
    }
}
