using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseSchool.Model.Entity;
using EnterpriseSchool.Model.Model;

namespace EnterpriseSchool.Model.Translator
{
  public  class ResultTranslator : BaseTranslator<Result, RESULT>
  {
      private SubjectTranslator subjectTranslator;
      private ClassTranslator classTranslator;
      private LevelTranslator levelTranslator;
      private StudentTranslator studentTranslator;
      private SessionTranslator sessionTranslator;
      private TermTranslator termTranslator;
      private BehaviourTranslator behaviourTranslator;
      private SkillTranslator skillTranslator;
      private ContinuousAssessmentTranslator continuousAssessmentTranslator;

      public ResultTranslator()
      {
          subjectTranslator= new SubjectTranslator();
          classTranslator = new ClassTranslator();
          levelTranslator = new LevelTranslator();
          studentTranslator = new StudentTranslator();
          sessionTranslator = new SessionTranslator();
          termTranslator = new TermTranslator();
          behaviourTranslator = new BehaviourTranslator();
          skillTranslator = new SkillTranslator();
          continuousAssessmentTranslator = new ContinuousAssessmentTranslator();
      }
      public override Result TranslateToModel(RESULT entity)
      {
          try
          {
              Result model = null;
              if (entity != null)
              {
                  model = new Result();
                  model.ResultId = entity.Result_Id;
                  model.ExamScore = entity.Exam_Score;
                  model.Total = entity.Total;
                  model.Grade = entity.Grade;
                  model.Subject = subjectTranslator.TranslateToModel(entity.SUBJECT);
                  model.Class = classTranslator.TranslateToModel(entity.CLASS);
                  model.Level = levelTranslator.TranslateToModel(entity.LEVEL);
                  model.Student = studentTranslator.TranslateToModel(entity.STUDENT);
                  model.Session = sessionTranslator.TranslateToModel(entity.SESSION);
                  model.Term = termTranslator.TranslateToModel(entity.TERM);
                  model.ContinuousAssessment =
                      continuousAssessmentTranslator.TranslateToModel(entity.CONTINUOUS_ASSESSMENT);
                  model.Behaviour = behaviourTranslator.TranslateToModel(entity.BEHAVIOUR);
                  model.Skill = skillTranslator.TranslateToModel(entity.SKILL);

              }
              return model;
          }
          catch (Exception)
          {
              
              throw;
          }
      }

      public override RESULT TranslateToEntity(Result model)
      {
          try
          {
              RESULT entity = null;
              if (model != null)
              {
                  entity= new RESULT();
                  entity.Result_Id = model.ResultId;
                  entity.Subject_Id = model.Subject.Id;
                  entity.Class_Id = model.Class.Id;
                  entity.Level_Id = model.Level.Id;
                  entity.Student_Id = model.Student.Id;
                  entity.Session_Id = model.Session.Id;
                  entity.Term_Id = model.Term.Id;
                  entity.Continuous_Assessment_Id = model.ContinuousAssessment.ContinuousAssessmentId;
                  entity.Exam_Score = model.ExamScore;
                  entity.Total = model.Total;
                  entity.Grade = model.Grade;
                  entity.Skill_Id = model.Skill.Id;
                  entity.Behaviour_Id = model.Behaviour.Id;

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
