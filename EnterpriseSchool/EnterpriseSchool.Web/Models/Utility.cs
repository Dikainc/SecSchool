using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using EnterpriseSchool.Business;
using EnterpriseSchool.Model.Model;

namespace EnterpriseSchool.Web.Models
{
    public class Utility
    {
        public const string ID = "Id";
        public const string TEXT = "Text";
        public const string NAME = "Name";
        public const string Select = "-- Select --";
        public const string SelectReligion = "-- Select Religion --";
        public const string SelectGenotype = "-- Select Genotype --";
        public const string SelectBloodGroup = "-- Select BloodGroup --";
        public const string SelectClass = "-- Select Class --";
        public const string SelectCountry = "-- Select Country --";
        public const string SelectState = "-- Select State --";
        public const string SelectLGA = "-- Select Local Govt --";
        public const string SelectPersonType = "-- Select Person Type --";
        public const string SelectSubject = "-- Select Subject --";
        public const string SelectTitle = "-- Select Title --";
        public const string SelectNationality = "-- Select Nationality --";
        public const string SelectStudentCategory = "-- Select StudentCategory --";
        public const string SelectStudentStatus = "-- Select StudentStatus --";
        public const string SelectLevel = "-- Select Level --";
        public const string SelectRole = "-- Select Role --";
        public const string SelectSex = "-- Select Sex --";
        public const string SelectSession = "-- Select Session --";
        public const string SelectTerm = "-- Select Semester --";



        public static List<SelectListItem> PopulateRoleSelectListItem()
        {
            try
            {
                RoleLogic roleLogic = new RoleLogic();
                List<Role> roles = roleLogic.GetAll();
                if (roles == null || roles.Count <= 0)
                {
                    return new List<SelectListItem>();
                }

                List<SelectListItem> roleList = new List<SelectListItem>();
                SelectListItem list = new SelectListItem();
                list.Value = "";
                list.Text = SelectRole;
                roleList.Add(list);
                foreach (Role role in roles)
                {
                    SelectListItem selectList = new SelectListItem();
                    selectList.Value = role.Id.ToString();
                    selectList.Text = role.RoleName;

                    roleList.Add(selectList);
                }

                return roleList;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public static List<SelectListItem> PopulateStaffTypeSelectListItem()
        {
            try
            {
                StaffTypeLogic staffTypeLogic = new StaffTypeLogic();
                List<StaffType> staffTypes = staffTypeLogic.GetAll();

                if (staffTypes == null || staffTypes.Count <= 0)
                {
                    return new List<SelectListItem>();
                }

                List<SelectListItem> staffTypeList = new List<SelectListItem>();

                SelectListItem list = new SelectListItem();
                list.Value = "";
                list.Text = "---Select Staff Type---";
                staffTypeList.Add(list);

                foreach (StaffType staffType in staffTypes)
                {
                    SelectListItem selectList = new SelectListItem();
                    selectList.Value = staffType.Id.ToString();
                    selectList.Text = staffType.Name;

                    staffTypeList.Add(selectList);
                }

                return staffTypeList;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public static StudentLevel StudentsClassLevel(Student student)
        {
            try
            {
                StudentLevelLogic staudentLevelLogic = new StudentLevelLogic();
                StudentLevel studentLevl =  staudentLevelLogic.GetModelBy(x => x.Session_Id == student.Id);
                return studentLevl;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public static List<SelectListItem> PopulateSexSelectListItem()
        {
            try
            {
                SexLogic sexLogic = new SexLogic();
                List<Sex> Sexes = sexLogic.GetAll();
                if (Sexes == null || Sexes.Count <= 0)
                {
                    return new List<SelectListItem>();
                }

                List<SelectListItem> sexList = new List<SelectListItem>();
                SelectListItem list = new SelectListItem();
                list.Value = "";
                list.Text = SelectSex;
                sexList.Add(list);
                foreach (Sex sex in Sexes)
                {
                    SelectListItem selectList = new SelectListItem();
                    selectList.Value = sex.Id.ToString();
                    selectList.Text = sex.Name;

                    sexList.Add(selectList);
                }

                return sexList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<SelectListItem> PopulatePersonTypeSelectListItem()
        {
            try
            {
                PersonTypeLogic personTypeLogic = new PersonTypeLogic();
                List<PersonType> personTypes = personTypeLogic.GetAll();
                if (personTypes == null || personTypes.Count <= 0)
                {
                    return new List<SelectListItem>();
                }

                List<SelectListItem> personTypeList = new List<SelectListItem>();
                SelectListItem list = new SelectListItem();
                list.Value = "";
                list.Text = SelectPersonType;
                personTypeList.Add(list);
                foreach (PersonType personType in personTypes)
                {
                    SelectListItem selectList = new SelectListItem();
                    selectList.Value = personType.Id.ToString();
                    selectList.Text = personType.PersonTypeName;

                    personTypeList.Add(selectList);
                }

                return personTypeList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<SelectListItem> PopulateReligionSelectListItem()
        {
            try
            {
                ReligionLogic religionLogic = new ReligionLogic();
                List<Religion> religions = religionLogic.GetAll();
                if (religions == null || religions.Count <= 0)
                {
                    return new List<SelectListItem>();
                }

                List<SelectListItem> religionList = new List<SelectListItem>();

                SelectListItem list = new SelectListItem();
                list.Value = "";
                list.Text = SelectReligion;
                religionList.Add(list);

                foreach (Religion religion in religions)
                {
                    SelectListItem selectList = new SelectListItem();
                    selectList.Value = religion.Id.ToString();
                    selectList.Text = religion.Name;

                    religionList.Add(selectList);
                }

                return religionList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<SelectListItem> PopulateStateSelectListItem()
        {
            try
            {
                StateLogic stateLogic = new StateLogic();
                List<State> states = stateLogic.GetAll();
                if (states == null || states.Count <= 0)
                {
                    return new List<SelectListItem>();
                }

                List<SelectListItem> stateList = new List<SelectListItem>();

                SelectListItem list = new SelectListItem();
                list.Value = "";
                list.Text = SelectState;
                stateList.Add(list);

                foreach (State state in states)
                {
                    SelectListItem selectList = new SelectListItem();
                    selectList.Value = state.Id;
                    selectList.Text = state.Name;

                    stateList.Add(selectList);
                }

                return stateList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<SelectListItem> PopulateLocalGovernmentSelectListItem()
        {
            try
            {
                LocalGovernmentLogic localGovernmentLogic = new LocalGovernmentLogic();
                List<LocalGovernment> lgas = localGovernmentLogic.GetAll();

                if (lgas == null || lgas.Count <= 0)
                {
                    return new List<SelectListItem>();
                }

                List<SelectListItem> stateList = new List<SelectListItem>();

                SelectListItem list = new SelectListItem();
                list.Value = "";
                list.Text = SelectLGA;
                stateList.Add(list);

                foreach (LocalGovernment lga in lgas)
                {
                    SelectListItem selectList = new SelectListItem();
                    selectList.Value = lga.Id.ToString();
                    selectList.Text = lga.Name;

                    stateList.Add(selectList);
                }

                return stateList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<SelectListItem> PopulateLocalGovernmentSelectListItemByStateId(string id)
        {
            try
            {
                LocalGovernmentLogic localGovernmentLogic = new LocalGovernmentLogic();
                List<LocalGovernment> lgas = localGovernmentLogic.GetModelsBy(l => l.State_Id == id);

                if (lgas == null || lgas.Count <= 0)
                {
                    return new List<SelectListItem>();
                }

                List<SelectListItem> stateList = new List<SelectListItem>();

                SelectListItem list = new SelectListItem();
                list.Value = "";
                list.Text = Select;
                stateList.Add(list);

                foreach (LocalGovernment lga in lgas)
                {
                    SelectListItem selectList = new SelectListItem();
                    selectList.Value = lga.Id.ToString();
                    selectList.Text = lga.Name;

                    stateList.Add(selectList);
                }

                return stateList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<SelectListItem> PopulateCountrySelectListItem()
        {
            try
            {
                CountryLogic countryLogic = new CountryLogic();
                List<Country> countries = countryLogic.GetAll();
                if (countries == null || countries.Count <= 0)
                {
                    return new List<SelectListItem>();
                }

                List<SelectListItem> countryList = new List<SelectListItem>();

                SelectListItem list = new SelectListItem();
                list.Value = "";
                list.Text = SelectCountry;
                countryList.Add(list);

                foreach (Country country in countries)
                {
                    SelectListItem selectList = new SelectListItem();
                    selectList.Value = country.Id.ToString();
                    selectList.Text = country.Name;

                    countryList.Add(selectList);
                }

                return countryList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<SelectListItem> PopulateNationalitySelectListItem()
        {
            try
            {
                NationalityLogic nationalityLogic = new NationalityLogic();
                List<Nationality> nationalities = nationalityLogic.GetAll();
                if (nationalities == null || nationalities.Count <= 0)
                {
                    return new List<SelectListItem>();
                }

                List<SelectListItem> NationalityList = new List<SelectListItem>();

                SelectListItem list = new SelectListItem();
                list.Value = "";
                list.Text = SelectNationality;
                NationalityList.Add(list);

                foreach (Nationality nationality in nationalities)
                {
                    SelectListItem selectList = new SelectListItem();
                    selectList.Value = nationality.Id.ToString();
                    selectList.Text = nationality.Name;

                    NationalityList.Add(selectList);
                }

                return NationalityList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<SelectListItem> PopulateTitleSelectListItem()
        {
            try
            {
                TitleLogic titleLogic = new TitleLogic();
                List<Title> titles = titleLogic.GetAll();

                if (titles == null || titles.Count <= 0)
                {
                    return new List<SelectListItem>();
                }

                List<SelectListItem> titlesList = new List<SelectListItem>();

                SelectListItem list = new SelectListItem();
                list.Value = "";
                list.Text = SelectTitle;
                titlesList.Add(list);

                foreach (Title title in titles)
                {
                    SelectListItem selectList = new SelectListItem();
                    selectList.Value = title.TitleId.ToString();
                    selectList.Text = title.TitleName;

                    titlesList.Add(selectList);
                }

                return titlesList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<SelectListItem> PopulateGenotypeSelectListItem()
        {
            try
            {
                GenotypeLogic genotypeLogic = new GenotypeLogic();
                List<Genotype> genotypes = genotypeLogic.GetAll();

                if (genotypes == null || genotypes.Count <= 0)
                {
                    return new List<SelectListItem>();
                }

                List<SelectListItem> genotypeList = new List<SelectListItem>();

                SelectListItem list = new SelectListItem();
                list.Value = "0";
                list.Text = SelectGenotype;
                genotypeList.Add(list);

                foreach (Genotype genotype in genotypes)
                {
                    SelectListItem selectList = new SelectListItem();
                    selectList.Value = genotype.Id.ToString();
                    selectList.Text = genotype.Name;

                    genotypeList.Add(selectList);
                }

                return genotypeList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<SelectListItem> PopulateBloodGroupSelectListItem()
        {
            try
            {
                BloodGroupLogic bloodGroupLogic = new BloodGroupLogic();
                List<BloodGroup> bloodGroups = bloodGroupLogic.GetAll();

                if (bloodGroups == null || bloodGroups.Count <= 0)
                {
                    return new List<SelectListItem>();
                }

                List<SelectListItem> bloodGroupList = new List<SelectListItem>();

                SelectListItem list = new SelectListItem();
                list.Value = "0";
                list.Text = SelectBloodGroup;
                bloodGroupList.Add(list);

                foreach (BloodGroup bloodGroup in bloodGroups)
                {
                    SelectListItem selectList = new SelectListItem();
                    selectList.Value = bloodGroup.Id.ToString();
                    selectList.Text = bloodGroup.Name;

                    bloodGroupList.Add(selectList);
                }

                return bloodGroupList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<SelectListItem> PopulateSubjectSelectListItem()
        {
            try
            {
                SubjectLogic subjectLogic = new SubjectLogic();
                List<Subject> subjects = subjectLogic.GetAll();

                if (subjects == null || subjects.Count <= 0)
                {
                    return new List<SelectListItem>();
                }

                List<SelectListItem> subjectList = new List<SelectListItem>();

                SelectListItem list = new SelectListItem();
                list.Value = "0";
                list.Text = SelectSubject;
                subjectList.Add(list);

                foreach (Subject subject in subjects)
                {
                    SelectListItem selectList = new SelectListItem();
                    selectList.Value = subject.Id.ToString();
                    selectList.Text = subject.Name;

                    subjectList.Add(selectList);
                }

                return subjectList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<SelectListItem> PopulateClassSelectListItem()
        {
            try
            {
               ClassLogic classLogic = new ClassLogic();
               List<Class> classes = classLogic.GetAll();

                if (classes == null || classes.Count <= 0)
                {
                    return new List<SelectListItem>();
                }

                List<SelectListItem> cClassList = new List<SelectListItem>();

                SelectListItem list = new SelectListItem();
                list.Value = "";
                list.Text = SelectClass;
                cClassList.Add(list);

                foreach (Class cClass in classes)
                {
                    SelectListItem selectList = new SelectListItem();
                    selectList.Value = cClass.Id.ToString();
                    selectList.Text = cClass.Name;

                    cClassList.Add(selectList);
                }

                return cClassList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<SelectListItem> PopulateStudentCategorySelectListItem()
        {
            try
            {
                StudentCategoryLogic studentCategoryLogic = new StudentCategoryLogic();
                List<StudentCategory> studentCategories = studentCategoryLogic.GetAll();

                if (studentCategories == null || studentCategories.Count <= 0)
                {
                    return new List<SelectListItem>();
                }

                List<SelectListItem> studentCategoryList = new List<SelectListItem>();

                SelectListItem list = new SelectListItem();
                list.Value = "";
                list.Text = SelectStudentCategory;
                studentCategoryList.Add(list);

                foreach (StudentCategory studentCategory in studentCategories)
                {
                    SelectListItem selectList = new SelectListItem();
                    selectList.Value = studentCategory.Id.ToString();
                    selectList.Text = studentCategory.StudentCategoryName;

                    studentCategoryList.Add(selectList);
                }

                return studentCategoryList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<SelectListItem> PopulateStudentStatusSelectListItem()
        {
            try
            {
               StudentStatusLogic studentStatusLogic = new StudentStatusLogic();
               List<StudentStatus> studentStatuses = studentStatusLogic.GetAll();

               if (studentStatuses == null || studentStatuses.Count <= 0)
                {
                    return new List<SelectListItem>();
                }

               List<SelectListItem> studentStatusList = new List<SelectListItem>();

                SelectListItem list = new SelectListItem();
                list.Value = "";
                list.Text = SelectStudentStatus;
                studentStatusList.Add(list);

                foreach (StudentStatus studentStatus in studentStatuses)
                {
                    SelectListItem selectList = new SelectListItem();
                    selectList.Value = studentStatus.Id.ToString();
                    selectList.Text = studentStatus.StudentStatusName;

                    studentStatusList.Add(selectList);
                }

                return studentStatusList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<SelectListItem> PopulateLevelSelectListItem()
        {
            try
            {
                LevelLogic levelLogic = new LevelLogic();
                List<Level> levels = levelLogic.GetAll();
                if (levels == null || levels.Count <= 0)
                {
                    return new List<SelectListItem>();
                }

                List<SelectListItem> levelList = new List<SelectListItem>();
                SelectListItem list = new SelectListItem();
                list.Value = "";
                list.Text = SelectLevel;
                levelList.Add(list);
                foreach (Level level in levels)
                {
                    SelectListItem selectlist = new SelectListItem();
                    selectlist.Value = level.Id.ToString();
                    selectlist.Text = level.Name;

                    levelList.Add(selectlist);
                }

                return levelList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static SessionTerm CurrentSessionTerm()
        {
            try
            {
                SessionTermLogic sessionTermLogic = new SessionTermLogic();
                SessionTerm CurrentSessionTerm = sessionTermLogic.GetModelBy(x => x.Active);
                if (CurrentSessionTerm == null || CurrentSessionTerm.Id <= 0)
                {
                    return null;
                }

                return CurrentSessionTerm;

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public static List<SelectListItem> PopulateSessionSelectListItem()
        {
            try
            {
                SessionLogic sessionLogic = new SessionLogic();
                List<Session> sessions = sessionLogic.GetAll();

                if (sessions == null || sessions.Count <= 0)
                {
                    return new List<SelectListItem>();
                }

                List<SelectListItem> selectItemList = new List<SelectListItem>();

                SelectListItem list = new SelectListItem();
                list.Value = "";
                list.Text = SelectSession;
                selectItemList.Add(list);

                foreach (Session session in sessions)
                {
                    SelectListItem selectList = new SelectListItem();
                    selectList.Value = session.Id.ToString();
                    selectList.Text = session.Name;

                    selectItemList.Add(selectList);
                }

                return selectItemList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<SelectListItem> PopulateTermSelectListItem()
        {
            try
            {
                TermLogic termLogic = new TermLogic();
                List<Term> terms = termLogic.GetModelsBy(x => x.Activated == true);

                if (terms == null || terms.Count <= 0)
                {
                    return new List<SelectListItem>();
                }

                List<SelectListItem> selectItemList = new List<SelectListItem>();

                SelectListItem list = new SelectListItem();
                list.Value = "";
                list.Text = SelectTerm;
                selectItemList.Add(list);

                foreach (Term term in terms)
                {
                    SelectListItem selectList = new SelectListItem();
                    selectList.Value = term.Id.ToString();
                    selectList.Text = term.Name;

                    selectItemList.Add(selectList);
                }

                return selectItemList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void BindDropdownItem<T>(DropDownList dropDownList, T items, string dataValueField, string dataTextField)
        {
            dropDownList.Items.Clear();

            dropDownList.DataValueField = dataValueField;
            dropDownList.DataTextField = dataTextField;


            dropDownList.DataSource = items;
            dropDownList.DataBind();
        }

    }
}