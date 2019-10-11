using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRecruitment.Models;

namespace Assessment.Models
{
    public class ExamSchedule
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public string CreatedId { get; set; }
        public DateTime DateExam { get; set; }
        public TimeSpan Duration { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedDate { get; set; }
        public Exam Exam { get; set; }
        public ICollection<ExamEmployee> ExamEmployees { get; set; }
        public ApplicationUser Created { get; set; }
    }
}
