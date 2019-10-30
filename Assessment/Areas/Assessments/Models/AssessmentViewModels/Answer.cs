using Assessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.Areas.Assessments.Models.AssessmentViewModels
{
    public class AnswerModel
    {
        public int ExamEmployeeId { get; set; }
        public int SectionId { get; set; }
        public int QuestionId { get; set; }
        public int? QuestionDetailId { get; set; }
        public bool? IsNext { get; set; }
        public IList<QuestionDetail> QuestionDetails { get; set; }
    }
}
