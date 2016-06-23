using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSchool.Model.Entity;
using EnterpriseSchool.Model.Model;

namespace EnterpriseSchool.Model.Translator
{
    public class PersonTypeTranslator : BaseTranslator<PersonType, PERSON_TYPE>
    {
        public override PersonType TranslateToModel(PERSON_TYPE entity)
        {
            try
            {
                PersonType model = null;
                if (entity != null)
                {
                    model = new PersonType();
                    model.Id = entity.Person_Type_Id;
                    model.PersonTypeName = entity.Person_Type_Name;
                    model.PersonTypeDescription = entity.Person_Type_Description;
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override PERSON_TYPE TranslateToEntity(PersonType model)
        {
            try
            {
                PERSON_TYPE entity = null;
                if (model != null)
                {
                    entity = new PERSON_TYPE();
                    entity.Person_Type_Id = model.Id;
                    entity.Person_Type_Name = model.PersonTypeName;
                    entity.Person_Type_Description = model.PersonTypeDescription;
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
