using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSchool.Model.Entity;
using EnterpriseSchool.Model.Model;

namespace EnterpriseSchool.Model.Translator
{
  public  class SkillTranslator : BaseTranslator<Skill, SKILL>
  {
      public override Skill TranslateToModel(SKILL entity)
      {
          try
          {
              Skill model = null;
              if (entity != null)
              {
                model = new Skill();
                  model.Id = entity.Skill_Id;
                  model.Handwriting = entity.Handwriting;
                  model.Fluency = entity.Fluency;
                  model.Games = entity.Games;
                  model.Sport = entity.Sport;
                  model.Gymnastics = entity.Gymnastics;
                  model.Drawing = entity.Drawing;
                  model.Crafts = entity.Crafts;
                  model.Music = entity.Music;
              }
              return model;
          }
          catch (Exception)
          {
              
              throw;
          }
      }

      public override SKILL TranslateToEntity(Skill model)
      {
          try
          {
              SKILL entity = null;
              if (model != null)
              {
                  entity = new SKILL();
                  entity.Skill_Id = model.Id;
                  entity.Handwriting = model.Handwriting;
                  entity.Fluency = model.Fluency;
                  entity.Games = model.Games;
                  entity.Sport = model.Sport;
                  entity.Gymnastics = model.Gymnastics;
                  entity.Drawing = model.Drawing;
                  entity.Crafts = model.Crafts;
                  entity.Music = model.Music;
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
