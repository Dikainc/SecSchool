using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSchool.Model.Entity;
using EnterpriseSchool.Model.Model;
using EnterpriseSchool.Model.Translator;

namespace EnterpriseSchool.Business
{
    public class PersonTypeLogic : BusinessBaseLogic<PersonType, PERSON_TYPE>
    {
        public PersonTypeLogic()
        {
            translator = new PersonTypeTranslator();
        }
    }
}
