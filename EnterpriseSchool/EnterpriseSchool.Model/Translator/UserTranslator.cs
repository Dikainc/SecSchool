using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSchool.Model.Entity;
using EnterpriseSchool.Model.Model;

namespace EnterpriseSchool.Model.Translator
{
  public  class UserTranslator : BaseTranslator<User, USER>
  {
      private RoleTranslator roleTranslator;
      private PersonTranslator personTranslator;

      public UserTranslator()
      {
          roleTranslator = new RoleTranslator();
          personTranslator = new PersonTranslator();
      }

      public override User TranslateToModel(USER entity)
      {
          try
          {
              User model = null;
              if (entity != null)
              {
                  model = new User();
                  model.Id = entity.User_Id;
                  model.UserName = entity.User_Name;
                  model.Password = entity.Password;
                  model.Role = roleTranslator.TranslateToModel(entity.ROLE);
                  model.Person = personTranslator.TranslateToModel(entity.PERSON);
                  model.LastLoginDate = entity.Last_Login_Date;
                  model.DateCreated = entity.Date_Created;
              }
              return model;
          }
          catch (Exception)
          {
              
              throw;
          }
      }

      public override USER TranslateToEntity(User model)
      {
          try
          {
              USER entity = null;
              if (model != null)
              {
                  entity = new USER();
                  entity.User_Id = model.Id;
                  entity.User_Name = model.UserName;
                  entity.Password = model.Password;
                  entity.Role_Id = model.Role.Id;
                  if (entity.Person_Id != null)
                  {
                      entity.Person_Id = model.Person.Id;
                  }
                  entity.Last_Login_Date = model.LastLoginDate;
                  entity.Date_Created = model.DateCreated;
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
