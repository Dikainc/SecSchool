using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSchool.Model.Entity;
using EnterpriseSchool.Model.Model;

namespace EnterpriseSchool.Model.Translator
{
   public class TermTranslator :BaseTranslator<Term, TERM>
   {
       public override Term TranslateToModel(TERM entity)
       {
           try
           {
               Term term = null;
               if (entity != null)
               {
                   term = new Term();
                   term.Id = entity.Term_Id;
                   term.Name = entity.Term_Name;
                   term.Activated = entity.Activated;
               }
               return term;
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public override TERM TranslateToEntity(Term term)
       {
           try
           {
               TERM entity = null;
               if (term != null)
               {
                   entity = new TERM();
                   entity.Term_Id = term.Id;
                   entity.Term_Name = term.Name;
                   entity.Activated = term.Activated;
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
