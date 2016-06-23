using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSchool.Model.Entity;
using EnterpriseSchool.Model.Model;

namespace EnterpriseSchool.Model.Translator
{
    public class AssignmentClassLevelTranslator : BaseTranslator<AssignmentClassLevel, ASSIGNMENT_CLASS_LEVEL>
    {
        private AssignmentTranslator assignmentTranslator;
        private ClassLevelTranslator classLevelTranslator;

        public AssignmentClassLevelTranslator()
        {
            assignmentTranslator = new AssignmentTranslator();
            classLevelTranslator = new ClassLevelTranslator();
        }

        public override AssignmentClassLevel TranslateToModel(ASSIGNMENT_CLASS_LEVEL entity)
        {
            AssignmentClassLevel model = null;
            if (entity != null)
            {
                model = new AssignmentClassLevel();
                model.Id = entity.Assignment_Id;
                model.Assignment = assignmentTranslator.Translate(entity.ASSIGNMENT);
                model.ClassLevel = classLevelTranslator.Translate(entity.CLASS_LEVEL);
            }
            return model;
        }

        public override ASSIGNMENT_CLASS_LEVEL TranslateToEntity(AssignmentClassLevel model)
        {
            ASSIGNMENT_CLASS_LEVEL entity = null;
            if (model != null)
            {
                entity = new ASSIGNMENT_CLASS_LEVEL();
                entity.Assignment_Class_Level_Id = model.Id;
                entity.Assignment_Id = model.Assignment.Id;
                entity.Class_Level_Id = model.ClassLevel.Id;
            }
            return entity;
        }
    }
}
