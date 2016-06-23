using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSchool.Model.Entity;
using EnterpriseSchool.Model.Model;

namespace EnterpriseSchool.Model.Translator
{
   public class SubjectLevelTranslator : BaseTranslator<SubjectLevel, SUBJECT_LEVEL>
   {
       private SubjectTranslator subjectTranslator;
       private LevelTranslator levelTranslator;

       public SubjectLevelTranslator()
       {
           subjectTranslator = new SubjectTranslator();
           levelTranslator = new LevelTranslator();
       }
       public override SubjectLevel TranslateToModel(SUBJECT_LEVEL entity)
       {
           try
           {
               SubjectLevel model = null;
               if (entity != null)
               {
                   model = new SubjectLevel();
                   model.Id = entity.Subject_Level_Id;
                   model.Subject = subjectTranslator.TranslateToModel(entity.SUBJECT);
                   model.Level = levelTranslator.TranslateToModel(entity.LEVEL);

               }
               return model;
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public override SUBJECT_LEVEL TranslateToEntity(SubjectLevel model)
       {
           try
           {
               SUBJECT_LEVEL entity = null;
               if (model != null)
               {
                   entity = new SUBJECT_LEVEL();
                   entity.Subject_Level_Id = model.Id;
                   entity.Subject_Id = model.Subject.Id;
                   entity.Level_Id = model.Level.Id;
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
