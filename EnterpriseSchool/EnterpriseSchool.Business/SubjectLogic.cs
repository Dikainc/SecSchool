using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSchool.Model.Entity;
using EnterpriseSchool.Model.Model;

namespace EnterpriseSchool.Business
{
   public class SubjectLogic : BusinessBaseLogic<Subject, SUBJECT>
   {
       public SubjectLogic()
       {
           translator = new Model.Translator.SubjectTranslator();
       }
    }
}
