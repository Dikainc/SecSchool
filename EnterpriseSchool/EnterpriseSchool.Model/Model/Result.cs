using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSchool.Model.Model
{
    public class Result
    {
        public long ResultId { get; set; }
        public Subject Subject { get; set; }
        public Class Class { get; set; }
        public Level Level { get; set; }
        public Student Student { get; set; }
        public Session Session { get; set; }
        public Skill Skill { get; set; }
        public Behaviour Behaviour { get; set; }
        public Term Term { get; set; }
        public ContinuousAssessment ContinuousAssessment { get; set; }
        public double? ExamScore { get; set; }
        public double? Total { get; set; }
        public string Grade { get; set; }
    }
}
