using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSchool.Model.Entity;
using EnterpriseSchool.Model.Model;

namespace EnterpriseSchool.Model.Translator
{
    public class StudentCategoryTranslator : BaseTranslator<StudentCategory, STUDENT_CATEGORY>
    {
        public override StudentCategory TranslateToModel(STUDENT_CATEGORY studentCategoryEntity)
        {
            try
            {
                StudentCategory studentCategory = null;
                if (studentCategoryEntity != null)
                {
                    studentCategory = new StudentCategory();
                    studentCategory.Id = studentCategoryEntity.Student_Category_Id;
                    studentCategory.StudentCategoryName = studentCategoryEntity.Student_Category_Name;
                    studentCategory.StudentCategoryDescrption = studentCategoryEntity.Student_Category_Descrption;
                }

                return studentCategory;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override STUDENT_CATEGORY TranslateToEntity(StudentCategory studentCategory)
        {
            try
            {
                STUDENT_CATEGORY studentCategoryEntity = null;
                if (studentCategory != null)
                {
                    studentCategoryEntity = new STUDENT_CATEGORY();
                    studentCategoryEntity.Student_Category_Id = studentCategory.Id;
                    studentCategoryEntity.Student_Category_Name = studentCategory.StudentCategoryName;
                    studentCategoryEntity.Student_Category_Descrption = studentCategory.StudentCategoryDescrption;
                }

                return studentCategoryEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }

}
