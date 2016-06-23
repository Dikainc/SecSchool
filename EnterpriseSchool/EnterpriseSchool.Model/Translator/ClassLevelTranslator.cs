using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSchool.Model.Entity;
using EnterpriseSchool.Model.Model;

namespace EnterpriseSchool.Model.Translator
{
   public class ClassLevelTranslator : BaseTranslator<ClassLevel, CLASS_LEVEL>
   {
       private ClassTranslator classTranslator;
       private LevelTranslator levelTranslator;

       public ClassLevelTranslator()
       {
           classTranslator = new ClassTranslator();
           levelTranslator = new LevelTranslator();
       }
       public override ClassLevel TranslateToModel(CLASS_LEVEL entity)
       {
           try
           {
               ClassLevel model = null;
               if (entity != null)
               {
                   model = new ClassLevel();
                   model.Id = entity.Class_Level_Id;
                   model.Class = classTranslator.TranslateToModel(entity.CLASS);
                   model.Level = levelTranslator.TranslateToModel(entity.LEVEL);

               }
               return model;
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public override CLASS_LEVEL TranslateToEntity(ClassLevel model)
       {
           try
           {
               CLASS_LEVEL entity = null;
               if (model != null)
               {
                   entity = new CLASS_LEVEL();
                   entity.Class_Level_Id = model.Id;
                   entity.Class_Id = model.Class.Id;
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
