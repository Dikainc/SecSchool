using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSchool.Model.Entity;
using EnterpriseSchool.Model.Model;

namespace EnterpriseSchool.Model.Translator
{
  public  class PersonTranslator :BaseTranslator<Person, PERSON>
  {
      private BloodGroupTranslator bloodGroupTranslator;
      private GenotypeTranslator genotypeTranslator;
      private PersonTypeTranslator personTypeTranslator;
      private SexTranslator sexTranslator;
      private LocalGovernmentTranslator localGovernmentTranslator;
      private NationalityTranslator nationalityTranslator;
      private ReligionTranslator religionTranslator;
      private StateTranslator stateTranslator;

      public PersonTranslator()
      {
          bloodGroupTranslator = new BloodGroupTranslator();
          genotypeTranslator= new GenotypeTranslator();
          personTypeTranslator = new PersonTypeTranslator();
          sexTranslator = new SexTranslator();
          localGovernmentTranslator = new LocalGovernmentTranslator();
          nationalityTranslator = new NationalityTranslator();
          religionTranslator = new ReligionTranslator();
          stateTranslator = new StateTranslator();
      }
      public override Person TranslateToModel(PERSON entity)
      {
          try
          {
              Person model = null;
              if (entity != null)
              {
                  model= new Person();
                  model.Id = entity.Person_Id;
                  model.ContactAddress = entity.Contact_Address;
                  model.DateEntered = entity.Date_Entered;
                  model.Genotype = genotypeTranslator.TranslateToModel(entity.GENOTYPE);
                  model.FirstName = entity.First_Name;
                  model.LastName = entity.Last_Name;
                  model.Initial = entity.Initial;
                  model.Title = entity.Title;
                  model.ImageFileUrl = entity.Image_File_Url;
                  model.SignatureFileUrl = entity.Signature_File_Url;
                  model.Email = entity.Email;
                  model.HomeTown = entity.Home_Town;
                  model.HomeAddress = entity.Home_Address;
                  model.MobilePhone = entity.Mobile_Phone;
                  model.OtherName = entity.Other_Name;
                  model.BloodGroup = bloodGroupTranslator.TranslateToModel(entity.BLOOD_GROUP);
                  model.PersonType = personTypeTranslator.TranslateToModel(entity.PERSON_TYPE);
                  model.Sex = sexTranslator.TranslateToModel(entity.SEX);
                  model.DateOfBirth = entity.Date_Of_Birth;
                  model.LocalGovernment = localGovernmentTranslator.TranslateToModel(entity.LOCAL_GOVERNMENT);
                  model.Nationality = nationalityTranslator.TranslateToModel(entity.NATIONALITY);
                  model.Religion = religionTranslator.TranslateToModel(entity.RELIGION);
                  model.State = stateTranslator.TranslateToModel(entity.STATE);
              }
              return model;
          }
          catch (Exception)
          {
                
              throw;
          }
      }

      public override PERSON TranslateToEntity(Person model)
      {
          try
          {
              PERSON entity = null;
              if (model != null)
              {
                  entity = new PERSON();
                  entity.Person_Id = model.Id;
                  entity.Contact_Address = model.ContactAddress;
                  entity.Genotype_Id = model.Genotype.Id;
                  entity.Date_Entered = model.DateEntered;
                  entity.Local_Government_Id = model.LocalGovernment.Id;
                  entity.Nationality_Id = model.Nationality.Id;
                  entity.Religion_Id = model.Religion.Id;
                  entity.Blood_Group_Id = model.BloodGroup.Id;
                  entity.Initial = model.Initial;
                  entity.Title = model.Title;
                  entity.Home_Town = model.HomeTown;
                  entity.Home_Address = model.HomeAddress;
                  entity.Image_File_Url = model.ImageFileUrl;
                  entity.Signature_File_Url = model.SignatureFileUrl;
                  entity.Email = model.Email;
                  entity.First_Name = model.FirstName;
                  entity.Last_Name = model.LastName;
                  entity.State_Id = model.State.Id;
                  entity.Mobile_Phone = model.MobilePhone;
                  entity.Other_Name = model.OtherName;
                  entity.Person_Type_Id = model.PersonType.Id;
                  entity.Sex_Id = model.Sex.Id;
                  entity.Date_Of_Birth = model.DateOfBirth;
                       
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
