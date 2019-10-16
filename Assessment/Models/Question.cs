using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assessment.Models;

namespace Assessment.Models
{
    public class Question
    {
        public int Id { get; set; }
        public int QuestionTypeId { get; set; }
        public string CreatedId { get; set; }
        public string Item { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime CreatedDate { get; set; }
        public QuestionType QuestionType { get; set; }
        public ICollection<QuestionDetail> QuestionDetails { get; set; }
        public ICollection<ExamQuestion> ExamQuestions { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public ApplicationUser Created { get; set; }
    }
}
