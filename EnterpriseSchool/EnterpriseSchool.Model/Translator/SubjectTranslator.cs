using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSchool.Model.Entity;
using EnterpriseSchool.Model.Model;

namespace EnterpriseSchool.Model.Translator
{
   public class SubjectTranslator : BaseTranslator<Subject, SUBJECT>
   {
       public override Subject TranslateToModel(SUBJECT entity)
       {
           try
           {
               Subject model = null;
               if (entity != null)
               {
                   model = new Subject();
                   model.Id = entity.Subject_Id;
                   model.Name = entity.Subject_Name;
               }
               return model;
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public override SUBJECT TranslateToEntity(Subject model)
       {
           try
           {
               SUBJECT entity = null;
               if (model != null)
               {
                   entity = new SUBJECT();
                   entity.Subject_Id = model.Id;
                   entity.Subject_Name = model.Name;
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
