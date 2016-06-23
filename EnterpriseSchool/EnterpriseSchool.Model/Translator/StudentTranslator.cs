using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSchool.Model.Entity;
using EnterpriseSchool.Model.Model;

namespace EnterpriseSchool.Model.Translator
{
 public   class StudentTranslator : BaseTranslator<Student, STUDENT>
 {
     private StudentCategoryTranslator studentCategoryTranslator;
     private StudentStatusTranslator studentStatusTranslator;
     private UserTranslator userTranslator;
     PersonTranslator personTranslator;

     
     public StudentTranslator()
     {
         studentCategoryTranslator = new StudentCategoryTranslator();
         studentStatusTranslator = new StudentStatusTranslator();
         userTranslator = new UserTranslator();
         personTranslator = new PersonTranslator();
     }
     public override Student TranslateToModel(STUDENT entity)
     {
         try
         {
             Student model = null;
             if (entity != null)
             {
                model = new Student();
                model.Id = entity.Student_Id;
                model.RegNo = entity.Reg_No;
                model.User = userTranslator.TranslateToModel(entity.USER);
                model.Category = studentCategoryTranslator.TranslateToModel(entity.STUDENT_CATEGORY);
                model.Status = studentStatusTranslator.TranslateToModel(entity.STUDENT_STATUS);
                 model.ParentPhone = entity.Parent_Phone;
                 model.ParentEmail = entity.Parent_Email;
                 model.Person = personTranslator.Translate(entity.PERSON);
                 model.FirstName = entity.First_Name;
                 model.LastName = entity.Last_Name;
                 model.OtherName = entity.Other_Names;

             }
             return model;
         }
         catch (Exception)
         {
             
             throw;
         }
     }

     public override STUDENT TranslateToEntity(Student model)
     {
         try
         {
             STUDENT entity = null;
             if (model != null)
             {
               entity = new STUDENT();
                 entity.Student_Id = model.Id;
                 entity.Reg_No = model.RegNo;
                 entity.User_Id = model.User.Id;
                 entity.Student_Category_Id = model.Category.Id;
                 entity.Student_Status_Id = model.Status.Id;
                 entity.Parent_Email = model.ParentEmail;
                 entity.Parent_Phone = model.ParentPhone;
                 if (entity.Person_Id != null)
                 {
                     entity.Person_Id = model.Person.Id;
                 }
                 entity.First_Name = model.FirstName;
                 entity.Last_Name = model.LastName;
                 entity.Other_Names = model.OtherName;
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
