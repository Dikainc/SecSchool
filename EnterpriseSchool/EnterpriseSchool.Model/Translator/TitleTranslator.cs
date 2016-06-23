using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSchool.Model.Entity;
using EnterpriseSchool.Model.Model;

namespace EnterpriseSchool.Model.Translator
{
   public class TitleTranslator : BaseTranslator<Title, TITLE>
   {
       public override Title TranslateToModel(TITLE entity)
       {
           try
           {
               Title model = null;
               if (entity != null)
               {
                   model = new Title();
                   model.TitleId = entity.Title_Id;
                   model.TitleName = entity.Title_Name;
               }
               return model;
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public override TITLE TranslateToEntity(Title model)
       {
           try
           {
               TITLE entity = null;
               if (model != null)
               {
                   entity = new TITLE();
                   entity.Title_Id = model.TitleId;
                   entity.Title_Name = model.TitleName;
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
