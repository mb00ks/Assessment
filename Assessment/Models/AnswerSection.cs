using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.Models
{
    public class AnswerSection
    {
        public int Id { get; set; }
        public int ExamEmployeeId { get; set; }
        public int ExamId { get; set; }
        public int SectionId { get; set; }
        public string CreatedId { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        [DataType(DataType.MultilineText)] public string Notes { get; set; }
        public DateTime CreatedDate { get; set; }
        public ExamEmployee ExamEmployee { get; set; }
        public Exam Exam { get; set; }
        public Section Section { get; set; }
        public ICollection<AnswerQuestion> AnswerQuestions { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public ApplicationUser Created { get; set; }

    }
}
