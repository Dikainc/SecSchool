using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSchool.Model.Entity;
using EnterpriseSchool.Model.Model;

namespace EnterpriseSchool.Model.Translator
{
    public class SessionTranslator : BaseTranslator<Session, SESSION>
    {
        public override Session TranslateToModel(SESSION entity)
        {
            try
            {
                Session model = null;
                if (entity != null)
                {
                    model = new Session();
                    model.Id = entity.Session_Id;
                    model.Activated = entity.Activated;
                    model.Name = entity.Session_Name;
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override SESSION TranslateToEntity(Session model)
        {
            try
            {
                SESSION entity = null;
                if (model != null)
                {
                    entity = new SESSION();
                    entity.Session_Id = model.Id;
                    entity.Activated = model.Activated;
                    entity.Session_Name = model.Name;
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
