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
    
    public partial class BEHAVIOUR_GRADING
    {
        public long Behaviour_Grading_Id { get; set; }
        public int Class_Id { get; set; }
        public int Level_Id { get; set; }
        public long Student_Id { get; set; }
        public int Term_Id { get; set; }
        public int Session_Id { get; set; }
        public int Grade { get; set; }
        public int Behaviour_Id { get; set; }
    
        public virtual BEHAVIOUR BEHAVIOUR { get; set; }
        public virtual CLASS CLASS { get; set; }
        public virtual LEVEL LEVEL { get; set; }
        public virtual SESSION SESSION { get; set; }
        public virtual STUDENT STUDENT { get; set; }
        public virtual TERM TERM { get; set; }
    }
}
