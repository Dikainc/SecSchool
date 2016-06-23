using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSchool.Model.Entity;
using EnterpriseSchool.Model.Model;

namespace EnterpriseSchool.Model.Translator
{
    public class StudentLevelTranslator :BaseTranslator<StudentLevel, STUDENT_LEVEL>
    {
        private LevelTranslator levelTranslator;
        private SessionTranslator sessionTranslator;
        private ClassTranslator classTranslator;
        private StudentTranslator studentTranslator;

        public StudentLevelTranslator()
        {
            levelTranslator = new LevelTranslator();
            sessionTranslator = new SessionTranslator();
            classTranslator = new ClassTranslator();
            studentTranslator = new StudentTranslator();
        }
        
        public override StudentLevel TranslateToModel(STUDENT_LEVEL entity)
        {
            StudentLevel model = null;
            if(entity != null)
            {
                model = new StudentLevel();
                model.Id = entity.Student_Level_Id;
                model.Class = classTranslator.Translate(entity.CLASS);
                model.Level = levelTranslator.Translate(entity.LEVEL);
                model.Session = sessionTranslator.Translate(entity.SESSION);
                model.Student = studentTranslator.Translate(entity.STUDENT);
            }
            return model;
        }

        public override STUDENT_LEVEL TranslateToEntity(StudentLevel model)
        {
            STUDENT_LEVEL entity = null;
            if (model != null)
            {
                entity = new STUDENT_LEVEL();
                entity.Student_Level_Id = model.Id;
                entity.Class_Id = model.Class.Id;
                entity.Level_Id = model.Level.Id;
                entity.Session_Id = model.Session.Id;
                entity.Student_Id = model.Student.Id;
            }
            return entity;
        }
    }
}
