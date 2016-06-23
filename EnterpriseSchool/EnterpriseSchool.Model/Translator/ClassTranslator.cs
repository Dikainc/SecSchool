using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSchool.Model.Entity;
using EnterpriseSchool.Model.Model;

namespace EnterpriseSchool.Model.Translator
{
   public class ClassTranslator : BaseTranslator<Class, CLASS>
   {
       public override Class TranslateToModel(CLASS entity)
       {
           try
           {
               Class model = null;
               if (entity != null)
               {
                   model = new Class();
                   model.Id = entity.Class_Id;
                   model.Name = entity.Class_Name;
                   model.Activated = entity.Activated;
               }
               return model;
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public override CLASS TranslateToEntity(Class model)
       {
           try
           {
               CLASS entity = null;
               if (model != null)
               {
                  entity = new CLASS();
                   entity.Class_Id = model.Id;
                   entity.Class_Name = model.Name;
                   entity.Activated = model.Activated;
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
