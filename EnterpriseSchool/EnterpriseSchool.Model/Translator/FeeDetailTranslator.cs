using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSchool.Model.Entity;
using EnterpriseSchool.Model.Model;

namespace EnterpriseSchool.Model.Translator
{
  public  class FeeDetailTranslator : BaseTranslator<FeeDetail, FEE_DETAIL>
  {
      private FeeTranslator feeTranslator;
      private FeeTypeTranslator feeTypeTranslator;
      private LevelTranslator levelTranslator;
      private SessionTranslator sessionTranslator;

      public FeeDetailTranslator()
      {
          feeTranslator = new FeeTranslator();
          feeTypeTranslator = new FeeTypeTranslator();
          levelTranslator= new LevelTranslator();
          sessionTranslator = new SessionTranslator();
      }
      public override FeeDetail TranslateToModel(FEE_DETAIL entity)
      {
          try
          {
              FeeDetail model = null;
              if (entity != null)
              {
                model = new FeeDetail();
                  model.Id = entity.Fee_Detail_Id;
                  model.Fee = feeTranslator.TranslateToModel(entity.FEE);
                  model.FeeType = feeTypeTranslator.TranslateToModel(entity.FEE_TYPE);
                  model.Level = levelTranslator.TranslateToModel(entity.LEVEL);
                  model.Session = sessionTranslator.TranslateToModel(entity.SESSION);

              }
              return model;
          }
          catch (Exception)
          {
              
              throw;
          }
      }

      public override FEE_DETAIL TranslateToEntity(FeeDetail model)
      {
          try
          {
              FEE_DETAIL entity = null;
              if (model != null)
              {
                  entity = new FEE_DETAIL();
                  entity.Fee_Detail_Id = model.Id;
                  entity.Fee_Id = model.Fee.Id;
                  entity.Fee_Type_Id = model.FeeType.Id;
                  entity.Level_Id = model.Level.Id;
                  entity.Session_Id = model.Session.Id;
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
