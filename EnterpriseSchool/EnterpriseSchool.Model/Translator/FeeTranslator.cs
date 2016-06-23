using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSchool.Model.Entity;
using EnterpriseSchool.Model.Model;

namespace EnterpriseSchool.Model.Translator
{
    public class FeeTranslator : BaseTranslator<Fee, FEE>
    {
        public override Fee TranslateToModel(FEE entity)
        {
            try
            {
                Fee model = null;
                if (entity != null)
                {
                    model = new Fee();
                    model.Id = entity.Fee_Id;
                    model.Amount = entity.Amount;
                    model.Name = entity.Fee_Name;
                    model.Description = entity.Fee_Description;
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override FEE TranslateToEntity(Fee model)
        {
            try
            {
                FEE entity = null;
                if (model != null)
                {
                    entity = new FEE();
                    entity.Fee_Id = model.Id;
                    entity.Amount = model.Amount;
                    entity.Fee_Name = model.Name;
                    entity.Fee_Description = model.Description;
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
