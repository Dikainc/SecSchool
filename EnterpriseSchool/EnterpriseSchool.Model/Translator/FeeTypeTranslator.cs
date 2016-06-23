using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSchool.Model.Entity;
using EnterpriseSchool.Model.Model;

namespace EnterpriseSchool.Model.Translator
{
    public class FeeTypeTranslator : BaseTranslator<FeeType, FEE_TYPE>
    {
        public override FeeType TranslateToModel(FEE_TYPE entity)
        {
            try
            {
                FeeType model = null;
                if (entity != null)
                {
                   model = new FeeType();
                    model.Id = entity.Fee_Type_Id;
                    model.Name = entity.Fee_Type_Name;
                    model.Description = entity.Fee_Type_Description;
                }
                return model;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public override FEE_TYPE TranslateToEntity(FeeType model)
        {
            try
            {
                FEE_TYPE entity = null;
                if (model != null)
                {
                    entity= new FEE_TYPE();
                    entity.Fee_Type_Id = model.Id;
                    entity.Fee_Type_Name = model.Name;
                    entity.Fee_Type_Description = model.Description;
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
