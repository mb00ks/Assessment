using Assessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRecruitment.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public string CreatedId { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<ExamSection> ExamSections { get; set; }
        public ICollection<ExamSchedule> ExamSchedules { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<ExamQuestion> QuestionGroups { get; set; }
        public ApplicationUser Created { get; set; }
    }
}
