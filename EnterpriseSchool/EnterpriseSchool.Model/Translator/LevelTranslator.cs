using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSchool.Model.Entity;
using EnterpriseSchool.Model.Model;

namespace EnterpriseSchool.Model.Translator
{
   public  class LevelTranslator : BaseTranslator<Level , LEVEL>
   {
       public override Level TranslateToModel(LEVEL entity)
       {
           try
           {
               Level model = null;
               if (entity != null)
               {
                   model = new Level();
                   model.Id = entity.Level_Id;
                   model.Name = entity.Level_Name;
                   model.Activated = entity.Activated;
                   
               }
               return model;
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public override LEVEL TranslateToEntity(Level model)
       {
           try
           {
               LEVEL entity = null;
               if (model != null)
               {
                  entity = new LEVEL();
                   entity.Level_Id = model.Id;
                   entity.Level_Name = model.Name;
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
