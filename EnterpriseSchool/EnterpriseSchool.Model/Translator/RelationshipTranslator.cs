using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSchool.Model.Entity;
using EnterpriseSchool.Model.Model;

namespace EnterpriseSchool.Model.Translator
{
    public class RelationshipTranslator : BaseTranslator<Relationship, RELATIONSHIP>
    {
        public override Relationship TranslateToModel(RELATIONSHIP entity)
        {
            Relationship model = null;
            if (entity != null)
            {
                model = new Relationship();
                model.Id = entity.Relationship_Id;
                model.Name = entity.Relationship_Name;
                model.Activated = entity.Activated;
            }
            return model;
        }

        public override RELATIONSHIP TranslateToEntity(Relationship model)
        {
            RELATIONSHIP entity = null;
            if (model != null)
            {
                entity.Relationship_Id = model.Id;
                entity.Relationship_Name = model.Name;
                entity.Activated = model.Activated;
            }
            return entity;
        }
    }
}
