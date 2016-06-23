using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSchool.Model.Entity;
using EnterpriseSchool.Model.Model;

namespace EnterpriseSchool.Model.Translator
{
    public class SessionTermTranslator : BaseTranslator<SessionTerm, SESSION_TERM>
    {
        private SessionTranslator sessionTranslator;
        private TermTranslator termTranslator;
        public SessionTermTranslator()
        {
            sessionTranslator = new SessionTranslator();
            termTranslator = new TermTranslator();
        }
        public override SessionTerm TranslateToModel(SESSION_TERM entity)
        {
            try
            {
                SessionTerm model = null;
                if (entity != null)
                {
                    model = new SessionTerm();
                    model.Id = entity.Session_Term_Id;
                    model.StartDate = entity.Start_Date;
                    model.EndDate = entity.End_Date;
                    model.Session = sessionTranslator.TranslateToModel(entity.SESSION);
                    model.Term = termTranslator.TranslateToModel(entity.TERM);
                    model.Active = entity.Active;
                }
                return model;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public override SESSION_TERM TranslateToEntity(SessionTerm model)
        {
            try
            {
                SESSION_TERM entity = null;
                if (model != null)
                {
                    entity = new SESSION_TERM();
                    entity.Session_Term_Id = model.Id;
                    entity.Session_Id = model.Session.Id;
                    entity.Term_Id = model.Term.Id;
                    entity.Start_Date = model.StartDate;
                    entity.End_Date = model.EndDate;
                    entity.Active = model.Active;
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
