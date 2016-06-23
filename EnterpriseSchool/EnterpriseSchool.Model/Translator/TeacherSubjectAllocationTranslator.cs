using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSchool.Model.Entity;
using EnterpriseSchool.Model.Model;

namespace EnterpriseSchool.Model.Translator
{
    public class TeacherSubjectAllocationTranslator : BaseTranslator<TeacherSubjectAllocation, TEACHER_SUBJECT_ALLOCATION>
    {
        private StaffTranslator staffTranslator;
       private LevelTranslator levelTranslator;
       private ClassTranslator classTranslator;
       private SessionTranslator sessionTranslator;
        private SubjectTranslator subjectTranslator;

       public TeacherSubjectAllocationTranslator()
       {
           staffTranslator = new StaffTranslator();
           levelTranslator = new LevelTranslator();
           classTranslator = new ClassTranslator();
           sessionTranslator = new SessionTranslator();
           subjectTranslator = new SubjectTranslator();
       }
       public override TeacherSubjectAllocation TranslateToModel(TEACHER_SUBJECT_ALLOCATION entity)
       {
           try
           {
               TeacherSubjectAllocation model = null;
               if (entity != null)
               {
                   model = new TeacherSubjectAllocation();
                   model.Id = entity.Teacher_Subject_Allocation_Id;
                   model.Activated = entity.Activated;
                   model.Staff = staffTranslator.TranslateToModel(entity.STAFF);
                   model.Level = levelTranslator.TranslateToModel(entity.LEVEL);
                   model.Class = classTranslator.TranslateToModel(entity.CLASS);
                   model.Session = sessionTranslator.TranslateToModel(entity.SESSION);
                   model.SubJect = subjectTranslator.Translate(entity.SUBJECT);
               }
               return model;
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public override TEACHER_SUBJECT_ALLOCATION TranslateToEntity(TeacherSubjectAllocation model)
       {
           try
           {
               TEACHER_SUBJECT_ALLOCATION entity = null;
               if (model != null)
               {
                   entity = new TEACHER_SUBJECT_ALLOCATION();
                   entity.Teacher_Subject_Allocation_Id = model.Id;
                   entity.Staff_Id = model.Staff.Id;
                   entity.Level_Id = model.Level.Id;
                   entity.Class_Id = model.Class.Id;
                   entity.Session_Id = model.Session.Id;
                   entity.Activated = model.Activated;
                   entity.SubJect_Id = model.SubJect.Id;

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
