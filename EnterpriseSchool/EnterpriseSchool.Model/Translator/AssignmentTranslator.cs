using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSchool.Model.Entity;
using EnterpriseSchool.Model.Model;

namespace EnterpriseSchool.Model.Translator
{
    public class AssignmentTranslator : BaseTranslator<Assignment, ASSIGNMENT>
    {
        private ClassLevelTranslator classLevelTranslator;
        private StaffTranslator staffTranslator;
        private SubjectTranslator subjectTranslator;

        public AssignmentTranslator()
        {
            classLevelTranslator = new ClassLevelTranslator();
            staffTranslator = new StaffTranslator();
            subjectTranslator = new SubjectTranslator();
        }
        public override Assignment TranslateToModel(ASSIGNMENT entity)
        {
            Assignment model = null;
            if (entity != null)
            {
                model = new Assignment();
                model.Id = entity.Assignment_Id;
                model.Topic = entity.Assignment_Topic;
                model.ClassLevel = classLevelTranslator.Translate(entity.CLASS_LEVEL);
                model.Active = entity.Active;
                model.AttachedFileLink = entity.Attached_File_Link;
                model.Description = entity.Assignment_Description;
                model.Date = entity.Date;
                model.DateDue = entity.Date_Due;
                model.Staff = staffTranslator.Translate(entity.STAFF);
                model.Subject = subjectTranslator.Translate(entity.SUBJECT);
            }
            return model;
        }

        public override ASSIGNMENT TranslateToEntity(Assignment model)
        {
            ASSIGNMENT entity = null;
            if (model != null)
            {
                entity = new ASSIGNMENT();
                entity.Assignment_Id = model.Id;
                entity.Assignment_Description = model.Description;
                entity.Assignment_Topic = model.Topic;
                entity.Attached_File_Link = model.AttachedFileLink;
                entity.Class_Level_Id = model.ClassLevel.Id;
                entity.Date = model.Date;
                entity.Date_Due = model.DateDue;
                entity.Active = model.Active;
                entity.Staff_id = model.Staff.Id;
                entity.Subject_Id = model.Subject.Id;
            }
            return entity;
        }
    }
}
