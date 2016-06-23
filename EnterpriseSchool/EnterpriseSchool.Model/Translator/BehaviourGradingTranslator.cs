using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSchool.Model.Entity;
using EnterpriseSchool.Model.Model;

namespace EnterpriseSchool.Model.Translator
{
    public class BehaviourGradingTranslator : BaseTranslator<BehaviourGrading, BEHAVIOUR_GRADING>
    {
        private BehaviourTranslator behaviourTranslator;
        private ClassTranslator classTranslator;
        private LevelTranslator levelTranslator;
        private SessionTranslator sessionTranslator;
        private StudentTranslator studentTranslator;
        private TermTranslator termTranslator;

        public BehaviourGradingTranslator()
        {
            behaviourTranslator = new BehaviourTranslator();
            classTranslator = new ClassTranslator();
            levelTranslator = new LevelTranslator();
            sessionTranslator = new SessionTranslator();
            studentTranslator = new StudentTranslator();
            termTranslator = new TermTranslator();
        }
        public override BehaviourGrading TranslateToModel(BEHAVIOUR_GRADING entity)
        {
            BehaviourGrading model = null;
            if (entity != null)
            {
                model = new BehaviourGrading();
                model.Id = entity.Behaviour_Grading_Id;
                model.Class = classTranslator.Translate(entity.CLASS);
                model.Level = levelTranslator.Translate(entity.LEVEL);
                model.Session = sessionTranslator.Translate(entity.SESSION);
                model.Student = studentTranslator.Translate(entity.STUDENT);
                model.Term = termTranslator.Translate(entity.TERM);
                model.Grade = entity.Grade;
                model.Behaviour = behaviourTranslator.Translate(entity.BEHAVIOUR);
            }
            return model;
        }

        public override BEHAVIOUR_GRADING TranslateToEntity(BehaviourGrading model)
        {
            BEHAVIOUR_GRADING entity = null;
            if (model != null)
            {
                entity = new BEHAVIOUR_GRADING();
                entity.Behaviour_Grading_Id = model.Id;
                entity.Class_Id = model.Class.Id;
                entity.Level_Id = model.Level.Id;
                entity.Student_Id = model.Student.Id;
                entity.Term_Id = model.Term.Id;
                entity.Session_Id = model.Session.Id;
                entity.Grade = model.Grade;
                entity.Behaviour_Id = model.Behaviour.Id;
            }
            return entity;
        }

    }
}
