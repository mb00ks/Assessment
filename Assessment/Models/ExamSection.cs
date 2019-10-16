using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assessment.Models;

namespace Assessment.Models
{
    public class ExamSection
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public string CreatedId { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime CreatedDate { get; set; }
        public Exam Exam { get; set; }
        public ICollection<ExamQuestion> ExamQuestions { get; set; }
        public ApplicationUser Created { get; set; }
    }
}
