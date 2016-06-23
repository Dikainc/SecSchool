using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSchool.Model.Entity;
using EnterpriseSchool.Model.Model;

namespace EnterpriseSchool.Model.Translator
{
    public class AssignmentGradingTranslator : BaseTranslator<AssignmentGrading, ASSIGNMENT_GRADING>
    {
        private AssignmentTranslator assignmentTranslator;

        public AssignmentGradingTranslator()
        {
            assignmentTranslator = new AssignmentTranslator();
        }
        public override AssignmentGrading TranslateToModel(ASSIGNMENT_GRADING entity)
        {
            AssignmentGrading model = null;
            if (entity != null)
            {
                model = new AssignmentGrading();
                model.Id = entity.Assignment_Grading_Id;
                model.Assignment = assignmentTranslator.Translate(entity.ASSIGNMENT);
                model.Grade = entity.Assignment_Grade;
            }
            return model;
        }

        public override ASSIGNMENT_GRADING TranslateToEntity(AssignmentGrading model)
        {
            ASSIGNMENT_GRADING entity = null;
            if (model != null)
            {
                entity = new ASSIGNMENT_GRADING();
                entity.Assignment_Grading_Id = model.Id;
                entity.Assignment_Id = model.Assignment.Id;
                entity.Assignment_Grade = model.Grade;
            }
            return entity;
        }
    }
}
