using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSchool.Model.Entity;
using EnterpriseSchool.Model.Model;

namespace EnterpriseSchool.Model.Translator
{
  public  class BloodGroupTranslator : BaseTranslator<BloodGroup , BLOOD_GROUP>
  {
      public override BloodGroup TranslateToModel(BLOOD_GROUP entity)
      {
          try
          {
              BloodGroup model = null;
              if (entity != null)
              {
                 model = new BloodGroup();
                  model.Id = entity.Blood_Group_Id;
                  model.Name = entity.Blood_Group_Name;
                  model.Activated = entity.Activated;

              }
              return model;
          }
          catch (Exception)
          {
              
              throw;
          }
      }

      public override BLOOD_GROUP TranslateToEntity(BloodGroup model)
      {
          try
          {
              BLOOD_GROUP entity = null;
              if (model != null)
              {
                  entity = new BLOOD_GROUP();
                  entity.Blood_Group_Id = model.Id;
                  entity.Blood_Group_Name = model.Name;
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
