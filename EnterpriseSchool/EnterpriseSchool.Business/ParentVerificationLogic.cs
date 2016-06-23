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
    public class ParentVerificationLogic : BusinessBaseLogic<ParentVerification, PARENT_VERIFICATION>
    {
        public ParentVerificationLogic()
        {
            translator = new ParentVerificationTranslator();
        }

        public bool Update(ParentVerification parentVerification)
        {
            try
            {
                PARENT_VERIFICATION entity = GetEntityBy(x => x.Parent_Verification_Id == parentVerification.Id);
                if (entity == null || entity.Parent_Verification_Id <= 0)
                {
                    throw new Exception(NoItemFound);
                }
                entity.Verified = true;

                int modifiedRecordCount = Save();
                if (modifiedRecordCount <= 0)
                {
                    throw new Exception(NoItemModified);
                }

                return true;
            }
            catch (Exception)
            {

                return true;
            }

        }

    }
}
