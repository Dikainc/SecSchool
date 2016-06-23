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
   public class SessionTermLogic : BusinessBaseLogic<SessionTerm, SESSION_TERM>
   {
       public SessionTermLogic()
       {
           translator= new SessionTermTranslator();
       }

       public bool Update(SessionTerm sessionTerm)
       {
           try
           {
               SESSION_TERM sessionTermEntity = GetEntityBy(x=>x.Session_Id == sessionTerm.Id);
               if (sessionTermEntity == null || sessionTermEntity.Session_Term_Id <= 0)
               {
                   throw new Exception(NoItemFound);
               }

               sessionTermEntity.Active = sessionTerm.Active;

               int modifiedRecordCount = Save();
               if (modifiedRecordCount <= 0)
               {
                   throw new Exception(NoItemModified);
               }
               return true;
           }
           catch (Exception)
           {

               return false;
           }
       }
   }
}
