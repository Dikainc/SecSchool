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
    
    public partial class USER
    {
        public USER()
        {
            this.PARENT = new HashSet<PARENT>();
            this.STAFF = new HashSet<STAFF>();
            this.STUDENT = new HashSet<STUDENT>();
        }
    
        public long User_Id { get; set; }
        public string User_Name { get; set; }
        public string Password { get; set; }
        public long Role_Id { get; set; }
        public Nullable<long> Person_Id { get; set; }
        public Nullable<System.DateTime> Last_Login_Date { get; set; }
        public System.DateTime Date_Created { get; set; }
    
        public virtual ICollection<PARENT> PARENT { get; set; }
        public virtual PERSON PERSON { get; set; }
        public virtual ROLE ROLE { get; set; }
        public virtual ICollection<STAFF> STAFF { get; set; }
        public virtual ICollection<STUDENT> STUDENT { get; set; }
    }
}