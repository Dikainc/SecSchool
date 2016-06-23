using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSchool.Model.Entity;
using EnterpriseSchool.Model.Model;

namespace EnterpriseSchool.Model.Translator
{
   public class ContinuousAssessmentTranslator : BaseTranslator<ContinuousAssessment, CONTINUOUS_ASSESSMENT>
   {
       public override ContinuousAssessment TranslateToModel(CONTINUOUS_ASSESSMENT entity)
       {
           try
           {
               ContinuousAssessment model = null;
               if (entity != null)
               {
                   model = new ContinuousAssessment();
                   model.ContinuousAssessmentId = entity.Continuous_Assessment_Id;
                   model.CA1 = entity.CA1;
                   model.CA2 = entity.CA2;
                   model.CA3 = entity.CA3;
               }
               return model;
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public override CONTINUOUS_ASSESSMENT TranslateToEntity(ContinuousAssessment model)
       {
           try
           {
               CONTINUOUS_ASSESSMENT entity = null;
               if (model != null)
               {
                 entity = new CONTINUOUS_ASSESSMENT();
                   entity.Continuous_Assessment_Id = model.ContinuousAssessmentId;
                   entity.CA1 = model.CA1;
                   entity.CA2 = model.CA2;
                   entity.CA3 = model.CA3;
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
