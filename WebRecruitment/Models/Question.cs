using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRecruitment.Models;

namespace Assessment.Models
{
    public class Question
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public int TypeId { get; set; }
        public string Item { get; set; }
        public DateTime Created { get; set; }
        public Exam Exam { get; set; }
        public Type Type { get; set; }
        public ICollection<QuestionDetail> QuestionDetails { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}
