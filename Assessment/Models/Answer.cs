using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assessment.Models;

namespace Assessment.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public int ExamEmployeeId { get; set; }
        public int ExamSectionId { get; set; }
        public int QuestionId { get; set; }
        public string CreatedId { get; set; }
        public string Item { get; set; }
        public DateTime CreatedDate { get; set; }
        public ExamEmployee ExamEmployee { get; set; }
        public ExamSection ExamSection { get; set; }
        public Question Question { get; set; }
        public ICollection<AnswerDetail> AnswerDetails { get; set; }
        public ApplicationUser Created { get; set; }
    }
}
