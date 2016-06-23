using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSchool.Model.Entity;
using EnterpriseSchool.Model.Model;

namespace EnterpriseSchool.Model.Translator
{
   public class StudentStatusTranslator : BaseTranslator<StudentStatus, STUDENT_STATUS>
   {
       public override StudentStatus TranslateToModel(STUDENT_STATUS entity)
       {
           try
           {
               StudentStatus model = null;
               if (entity != null)
               {
                  model = new StudentStatus();
                   model.Id = entity.Student_Status_Id;
                   model.StudentStatusName = entity.Student_Status_Name;
                   model.StudentStatusDescription = entity.Student_Status_Description;
                   
               }
               return model;
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public override STUDENT_STATUS TranslateToEntity(StudentStatus model)
       {
           try
           {
               STUDENT_STATUS entity = null;
               if (model != null)
               {
                   entity = new STUDENT_STATUS();
                   entity.Student_Status_Id = model.Id;
                   entity.Student_Status_Name = model.StudentStatusName;
                   entity.Student_Status_Description = model.StudentStatusDescription;
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
