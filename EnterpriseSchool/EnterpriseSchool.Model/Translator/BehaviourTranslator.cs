using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSchool.Model.Entity;
using EnterpriseSchool.Model.Model;

namespace EnterpriseSchool.Model.Translator
{
   public class BehaviourTranslator : BaseTranslator<Behaviour, BEHAVIOUR>
   {
       public override Behaviour TranslateToModel(BEHAVIOUR entity)
       {
           try
           {
               Behaviour model = null;
               if (entity != null)
               {
                   model = new Behaviour();
                   model.Id = entity.Behaviour_Id;
                   model.Name = entity.Behaviour_Name;
               }
               return model;
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public override BEHAVIOUR TranslateToEntity(Behaviour model)
       {
           try
           {
               BEHAVIOUR entity = null;
               if (model != null)
               {
                   entity = new BEHAVIOUR();
                   entity.Behaviour_Id = model.Id;
                   entity.Behaviour_Name = model.Name;
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
