using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSchool.Model.Entity;
using EnterpriseSchool.Model.Model;

namespace EnterpriseSchool.Model.Translator
{
    public class ParentVerificationTranslator : BaseTranslator<ParentVerification, PARENT_VERIFICATION>
    {
       private StudentTranslator studentTranslator;

        public ParentVerificationTranslator()
        {
            studentTranslator = new StudentTranslator();
        }
        public override ParentVerification TranslateToModel(PARENT_VERIFICATION entity)
        {
            ParentVerification model = null;
            if (entity != null)
            {
                model = new ParentVerification();
                model.Id = entity.Parent_Verification_Id;
                model.Student = studentTranslator.Translate(entity.STUDENT);
                model.Detail = entity.Verification_Detail;
                model.Verified = entity.Verified;
            }
            return model;
        }

        public override PARENT_VERIFICATION TranslateToEntity(ParentVerification model)
        {
            PARENT_VERIFICATION entity = null;
            if (model != null)
            {
                entity = new PARENT_VERIFICATION();
                entity.Parent_Verification_Id = model.Id;
                entity.Verification_Detail = model.Detail;
                entity.Verified = model.Verified;
                entity.Student_Id = model.Student.Id;
            }
            return entity;
        }
    }
}
