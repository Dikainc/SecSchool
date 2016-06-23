using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSchool.Model.Entity;
using EnterpriseSchool.Model.Model;

namespace EnterpriseSchool.Model.Translator
{
   public class ParentStudentTranslator : BaseTranslator<ParentStudent, PARENT_STUDENT>
   {
       private ParentTranslator parentTranslator;
       private StudentTranslator studentTranslator;

       public ParentStudentTranslator()
       {
           parentTranslator = new ParentTranslator();
           studentTranslator = new StudentTranslator();
       }
       public override ParentStudent TranslateToModel(PARENT_STUDENT entity)
       {
           try
           {
               ParentStudent model = null;
               if (entity != null)
               {
                   model = new ParentStudent();
                   model.Id = entity.Parent_Student_Id;
                   model.Parent = parentTranslator.TranslateToModel(entity.PARENT);
                   model.Student = studentTranslator.TranslateToModel(entity.STUDENT);

               }
               return model;
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public override PARENT_STUDENT TranslateToEntity(ParentStudent model)
       {
           try
           {
               PARENT_STUDENT entity = null;
               if (model != null)
               {
                   entity = new PARENT_STUDENT();
                   entity.Parent_Student_Id = model.Id;
                   entity.Parent_Id = model.Parent.Id;
                   entity.Student_Id = model.Student.Id;
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
