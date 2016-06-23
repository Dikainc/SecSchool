using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSchool.Model.Entity;
using EnterpriseSchool.Model.Model;

namespace EnterpriseSchool.Model.Translator
{
   public class ParentTranslator : BaseTranslator<Parent, PARENT>
   {
       private UserTranslator userTranslator;
       private PersonTranslator personTranslator;
       private SexTranslator sexTranslator;
       RelationshipTranslator relationshipTranslator;

       public ParentTranslator()
       {
           userTranslator = new UserTranslator();
           sexTranslator = new SexTranslator();
           relationshipTranslator = new RelationshipTranslator();

       }
       public override Parent TranslateToModel(PARENT entity)
       {
           try
           {
               Parent model = null;
               if (entity != null)
               {
                   model = new Parent();
                   model.Id = entity.Parent_Id;
                   model.User = userTranslator.TranslateToModel(entity.USER);
                   model.Sex = sexTranslator.Translate(entity.SEX);
                   model.RelatinshipWithStudent = relationshipTranslator.Translate(entity.RELATIONSHIP);
                   model.PhoneNo = entity.Phone_No;
                   model.Address = entity.Address;
                   model.Verified = entity.Verified;
               }
               return model;
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public override PARENT TranslateToEntity(Parent model)
       {
           try
           {
               PARENT entity = null;
               if (model != null)
               {
                   entity = new PARENT();
                   entity.User_Id = model.User.Id;
                   entity.Relatinship_with_Student = model.RelatinshipWithStudent.Id;
                   entity.Sex_Id = model.Sex.Id;
                   entity.Phone_No = model.PhoneNo;
                   entity.Address = model.Address;
                   entity.Verified = model.Verified;
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
