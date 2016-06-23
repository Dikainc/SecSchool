using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSchool.Model.Entity;
using EnterpriseSchool.Model.Model;

namespace EnterpriseSchool.Model.Translator
{
   public class StaffTranslator : BaseTranslator<Staff, STAFF>
   {
       private StaffTypeTranslator staffTypeTranslator;
       private UserTranslator userTranslator;
       PersonTranslator personTranslator;
       
       public StaffTranslator()
       {
           staffTypeTranslator = new StaffTypeTranslator();
           userTranslator = new UserTranslator();
           personTranslator = new PersonTranslator();
       }
       public override Staff TranslateToModel(STAFF entity)
       {
           try
           {
               Staff model = null;
               if (entity != null)
               {
                   model = new Staff();
                   model.Id = entity.Staff_Id;
                   model.StaffType = staffTypeTranslator.TranslateToModel(entity.STAFF_TYPE);
                   model.User = userTranslator.TranslateToModel(entity.USER);
                   model.Person = personTranslator.Translate(entity.PERSON);
                   model.FirstName = entity.First_Name;
                   model.LastName = entity.Last_name;
                   model.OtherName = entity.Other_Names;

               }
               return model;
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public override STAFF TranslateToEntity(Staff model)
       {
           try
           {
               STAFF entity = null;
               if (model != null)
               {
                   entity = new STAFF();
                   entity.Staff_Type_Id = model.StaffType.Id;
                   entity.User_Id = model.User.Id;
                   entity.Staff_Id = model.Id;
                   if (entity.Person_Id != null )
                   {
                       entity.Person_Id = model.Person.Id;
                   }
                   entity.First_Name = model.FirstName;
                   entity.Last_name = model.LastName;
                   entity.Other_Names = model.OtherName;
               }
               return entity;
           }
           catch (Exception)
           {
               
               throw;
           }
       }
   }
}
