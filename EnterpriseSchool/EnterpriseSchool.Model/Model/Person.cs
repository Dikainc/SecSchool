using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSchool.Model.Model
{
    public class Person
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get 
            {
                if (this.FirstName != null && this.LastName != null)
                {
                    string FullName = FirstName + " " + LastName;
                    return FullName;
                }
                return null;
            }
        }
        public string OtherName { get; set; }
        public string Initial { get; set; }
        public string Title { get; set; }
        public string ImageFileUrl { get; set; }
        public string SignatureFileUrl { get; set; }
        public Sex Sex { get; set; }
        public string ContactAddress { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public State State { get; set; }
        public LocalGovernment LocalGovernment { get; set; }
        public string HomeTown { get; set; }
        public string HomeAddress { get; set; }
        public Religion Religion { get; set; }
        public Nationality Nationality { get; set; }
        public PersonType PersonType { get; set; }
        public BloodGroup BloodGroup { get; set; }
        public Genotype Genotype { get; set; }
        public System.DateTime DateEntered { get; set; }
    }
}
