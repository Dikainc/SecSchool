using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSchool.Model.Entity;
using EnterpriseSchool.Model.Model;

namespace EnterpriseSchool.Model.Translator
{
    public class RoleTranslator : BaseTranslator<Role, ROLE>
    {
        public override Role TranslateToModel(ROLE entity)
        {
            try
            {
                Role model = null;
                if (entity != null)
                {
                    model = new Role();
                    model.Id = entity.Role_Id;
                    model.RoleName = entity.Role_Name;
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override ROLE TranslateToEntity(Role model)
        {
            try
            {
                ROLE entity = null;
                if (model != null)
                {
                    entity = new ROLE();
                    entity.Role_Id = model.Id;
                    entity.Role_Name = model.RoleName;
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
